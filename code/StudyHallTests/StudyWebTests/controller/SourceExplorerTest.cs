using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using StudyWeb.Controllers;
using StudyWeb.Data;
using StudyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.Data.Sqlite;

namespace StudyHallTests.StudyWebTests.controller
{
    [TestFixture]
    public class SourceExplorerTest
    {

        private ApplicationDbContext context;
        private Mock<IDatabaseService> databaseServiceMock;

        [SetUp]
        public void SetUp()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            databaseServiceMock = new Mock<IDatabaseService>();
            this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                .ReturnsAsync(1);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

        [Test]
        public async Task IndexJsonResultTest()
        {
            var testSource = new Source
            {
                Id = 1,
                Title = "Test Source",
                Link = "http://example.com",
                Owner = "testUserId",
                Type = SourceTypes.Pdf
            };
            context.Source.Add(testSource);
            context.Note.Add(new Note { Id = 1, SourceId = 1, Text = "Test Note", Owner = "testUserId" });
            context.Tags.Add(new Tags { Id = 1, Name = "Test Tag" });
            context.NoteTags.Add(new NoteTags { NoteId = 1, TagId = 1 });
            await context.SaveChangesAsync();
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "testUserId")
            }));
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
            controller.HttpContext.Request.Headers["Accept"] = "application/json";

            var result = await controller.Index();

            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
            var okResult = result as OkObjectResult;
            var sources = okResult.Value as IEnumerable<Source>;
            Assert.IsNotNull(sources);
            Assert.That(sources, Has.Exactly(1).Items);
            Assert.That(sources.FirstOrDefault(), Is.EqualTo(testSource));
        }

        [Test]
        public async Task IndexUnauthorizedResultTest()
        {
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            controller.HttpContext.Request.Headers["Accept"] = "application/json";
            var result = await controller.Index();
            Assert.That(result, Is.InstanceOf(typeof(UnauthorizedObjectResult)));
        }

        [Test]
        public async Task IndexViewResultTest()
        {
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            var result = await controller.Index();
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));
        }

        [Test]
        public async Task View_NullId_ReturnsNotFoundResult()
        {
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var result = await controller.View(null);
            Assert.That(result, Is.InstanceOf(typeof(NotFoundResult)));
        }

        [Test]
        public async Task View_ViewResultTest()
        {
            context.Source.Add(new Source
                { Id = 130, Title = "title", Link = "link", Owner = "kenneth@uwg.com", Type = SourceTypes.Pdf });
            context.SaveChanges();
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var result = await controller.View(130);
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult.Model);
            Assert.That(viewResult.Model, Is.InstanceOf(typeof(Source)));
            Assert.AreEqual(130, ((Source)viewResult.Model).Id);
        }

        [Test]
        public async Task ViewResultNotFoundTest()
        {
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var result = await controller.View(999);
            Assert.That(result, Is.InstanceOf(typeof(NotFoundResult)));
        }

        [Test]
        public async Task Create_ValidData_ReturnsOkResult()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            var mockPdfUpload = new Mock<IFormFile>();
            var result = await controller.Create("Valid Title", "Valid Link", mockPdfUpload.Object, null, null,
                SourceTypes.Pdf);
            Assert.That(result, Is.InstanceOf(typeof(RedirectToActionResult)));
        }

        [Test]
        public async Task CreateViewResultTest()
        {
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var result = await controller.Create();
            Assert.That(result, Is.InstanceOf(typeof(PartialViewResult)));
        }

        [Test]
        public async Task CreateMissingTitleTest()
        {
            var controller = this.SetupControllerWithAuthenticatedUser();
            var result = await controller.Create(null, "link", null, null, null, SourceTypes.Video);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestResult)));
        }

        [Test]
        public async Task CreateMissingLinkPdfTest()
        {
            var controller = this.SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", null, null, null, null, SourceTypes.Pdf);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestResult)));
        }



        [Test]
        public async Task CreateMissingLinkImageTest()
        {
            var controller = this.SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", null, null, null, null, SourceTypes.Image);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestResult)));
        }

        [Test]
        public async Task CreateMissingLinkImageLinkTest()
        {
            var controller = this.SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", null, null, null, null, SourceTypes.ImageLink);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestResult)));
        }

        [Test]
        public async Task CreateMissingLinkVideoLinkTest()
        {
            var controller = this.SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", null, null, null, null, SourceTypes.VideoLink);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestResult)));
        }



        [TestCase(SourceTypes.Pdf, null, null, null, TestName = "Create_WithPdfTypeAndNoFileUpload_ReturnsBadRequest")]
        [TestCase(SourceTypes.Video, null, null, null,
            TestName = "Create_WithVideoTypeAndNoFileUpload_ReturnsBadRequest")]
        [TestCase(SourceTypes.Image, null, null, null,
            TestName = "Create_WithImageTypeAndNoFileUpload_ReturnsBadRequest")]
        [TestCase(SourceTypes.ImageLink, null, null, null,
            TestName = "Create_WithImageLinkTypeAndNoLink_ReturnsBadRequest")]
        public async Task CreateWithTypeSpecificValidation_ReturnsBadRequest(SourceTypes type, IFormFile? pdfUpload,
            IFormFile? videoUpload, IFormFile? imageUpload)
        {
            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", null, pdfUpload, videoUpload, imageUpload, type);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Create_WithJsonAcceptHeader_ReturnsOkObjectResult()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            controller.HttpContext.Request.Headers["Accept"] = "application/json";
            var result = await controller.Create("Title", "Link", null, null, null, SourceTypes.PdfLink);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Create_YoutubeLink_ReturnsBadRequestResult()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            controller.HttpContext.Request.Headers["Accept"] = "application/json";
            var result = await controller.Create("Title", "https://www.youtube.com/watch?v=5JvLV2-ngCI", null, null,
                null, SourceTypes.VideoLink);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Create_YoutubeLinkMissing_ReturnsBadRequestResult()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            controller.HttpContext.Request.Headers["Accept"] = "application/json";
            var result = await controller.Create("Title", "link", null, null, null, SourceTypes.VideoLink);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Create_WithoutJsonAcceptHeader_ReturnsRedirectToActionResult()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", "www.link.com", null, null, null, SourceTypes.PdfLink);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        }

        [Test]
        public async Task NoteInvalidInput_ReturnsBadRequest()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.Note("", 1, string.Empty);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task NoteUserNotAuthenticated_ReturnsUnauthorized()
        {
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            var result = await controller.Note("Note text", 1, string.Empty);
            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public async Task NoteValidInputEmptyTag_ReturnsOkResult()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            context.Source.Add(new Source
                { Id = 300, Title = "title", Link = "link", Owner = "kenneth@uwg.com", Type = SourceTypes.PdfLink });
            context.SaveChanges();
            var result = await controller.Note("Note text", 300, "");
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task NoteExceptionOccurs_ReturnsBadRequest()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                .Throws(new Exception());
            var result = await controller.Note("Note text", -1, string.Empty);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        private SourceExplorer SetupControllerWithAuthenticatedUser()
        {
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "testUser"),
            }));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            return controller;
        }

        [Test]
        public async Task Delete_WhenSourceExists_DeletesSourceAndReturnsOk()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.Delete(sourceId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Delete_WhenSourceDoesNotExist_ReturnsBadRequest()
        {
            var nonExistingSourceId = 99;
            var controller = SetupControllerWithAuthenticatedUser();
            this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                .Throws(new Exception());
            var result = await controller.Delete(nonExistingSourceId);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Delete_WhenSourceHasNotes_DeletesSourceAndNotesAndReturnsOk()
        {
            var sourceId = 120;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source With Notes" });
            context.Note.AddRange(
                new Note { Id = 100, SourceId = sourceId, Text = "Note 100" },
                new Note { Id = 120, SourceId = sourceId, Text = "Note 120" }
            );
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();

            var result = await controller.Delete(sourceId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        // [Test]
        // public async Task DeleteNote_WithValidNoteId_DeletesNoteAndReturnsOk()
        // {
        //     var noteId = 200;
        //     context.Note.Add(new Note { Id = noteId, Text = "Test Note", SourceId = 100 });
        //     context.SaveChanges();
        //
        //     var controller = SetupControllerWithAuthenticatedUser();
        //     var result = await controller.DeleteNote(noteId);
        //
        //     Assert.That(result, Is.InstanceOf<OkObjectResult>());
        //     var note = context.Note.Find(noteId);
        //     Assert.IsNull(note);
        // }

        [Test]
        public async Task DeleteNote_WithInvalidNoteId_ReturnsBadRequest()
        {
            var nonExistingNoteId = 99;
            var controller = SetupControllerWithAuthenticatedUser();
            this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                .Throws(new Exception());
            var result = await controller.DeleteNote(nonExistingNoteId);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        // [Test]
        // public async Task DeleteNote_WhenExceptionOccurs_ReturnsBadRequest()
        // {
        //     var noteId = 201;
        //     context.Note.Add(new Note { Id = noteId, Text = "Test Note", SourceId = 101 });
        //     context.SaveChanges();
        //
        //     var controller = SetupControllerWithAuthenticatedUser();
        //
        //     var failingContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
        //     failingContext.Setup(x => x.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
        //                   .ThrowsAsync(new Exception("Database error"));
        //     this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
        //                             .ThrowsAsync(new Exception("Database error"));
        //     controller = new SourceExplorer(failingContext.Object, this.databaseServiceMock.Object);
        //
        //     var result = await controller.DeleteNote(noteId);
        //
        //     Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        // }


        [Test]
        public async Task Edit_WithValidData_ReturnsOk()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.SaveChanges();
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.EditNote(100, "new text");

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Edit_WithInvalidData_ReturnsBadRequest()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.SaveChanges();
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.EditNote(101, "");

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Edit_WithInvalidNoteId_ReturnsNotFound()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.EditNote(101, "new text");

            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public async Task Edit_OwnerNull_ReturnsBadRequest()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.SaveChanges();
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "owner" });
            context.SaveChanges();
            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "testUser"),
            }));
            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = null! }
            };
            controller.ControllerContext = controllerContext;
            var result = await controller.EditNote(100, "new text");

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public async Task Edit_ThrowsException_ReturnsBadRequest()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.SaveChanges();
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                .Throws(new Exception());
            var result = await controller.EditNote(100, "new text");

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task AddTag_WithValidData_ReturnsOk()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.Tags.Add(new Tags { Id = 1, Name = "new tag" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.AddTag(sourceId, "new tag");

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task AddTag_WithInvalidData_ReturnsBadRequest()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.Tags.Add(new Tags { Id = 1, Name = "new tag" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.AddTag(sourceId, "");

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task AddTag_InvalidUser_ReturnsUnauthenticated()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.Tags.Add(new Tags { Id = 1, Name = "new tag" });
            context.SaveChanges();

            var controller = new SourceExplorer(context, this.databaseServiceMock.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "testUser"),
            }));
            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = null! }
            };
            controller.ControllerContext = controllerContext;
            var result = await controller.AddTag(sourceId, "new tag");

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public async Task AddTag_ExceptionDuringNewTag()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                .Throws(new Exception());
            var result = await controller.AddTag(sourceId, "new tag");

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task AddTag_TagAlreadyAdded_ReturnsBadRequestResult()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.Tags.Add(new Tags { Id = 1, Name = "new tag" });
            this.context.NoteTags.Add(new NoteTags { NoteId = 100, TagId = 1 });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.AddTag(sourceId, "new tag");

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task AddTag_ExceptionDuringAddingTagToNote()
        {
            var sourceId = 100;
            context.Source.Add(new Source { Id = sourceId, Title = "Test Source" });
            context.Note.Add(new Note { Id = 100, SourceId = sourceId, Text = "Test Note", Owner = "testUser" });
            context.Tags.Add(new Tags { Id = 1, Name = "new tag" });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            this.databaseServiceMock.Setup(x => x.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                .Throws(new Exception());
            var result = await controller.AddTag(sourceId, "new tag");

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }
    }
}
