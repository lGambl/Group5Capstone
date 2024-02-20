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

namespace StudyHallTests.StudyWebTests.controller
{
    [TestFixture]
    public class SourceExplorerTest
    {

        private ApplicationDbContext context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            context = new ApplicationDbContext(options);
            context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

        [Test]
        public async Task IndexJsonResultTest()
        {
            var controller = new SourceExplorer(context);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                { new Claim(ClaimTypes.NameIdentifier, "testUserId") }));
            controller.ControllerContext = new ControllerContext
            { HttpContext = new DefaultHttpContext { User = user } };
            controller.HttpContext.Request.Headers["Accept"] = "application/json";
            var result = await controller.Index();
            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public async Task IndexUnauthorizedResultTest()
        {
            var controller = new SourceExplorer(context);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            controller.HttpContext.Request.Headers["Accept"] = "application/json";
            var result = await controller.Index();
            Assert.That(result, Is.InstanceOf(typeof(UnauthorizedObjectResult)));
        }

        [Test]
        public async Task IndexViewResultTest()
        {
            var controller = new SourceExplorer(context);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
            var result = await controller.Index();
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));
        }

        [Test]
        public async Task View_ViewResultTest()
        {
            context.Source.Add(new Source
            { Id = 130, Title = "title", Link = "link", Owner = "kenneth@uwg.com", Type = SourceTypes.Pdf });
            context.SaveChanges();
            var controller = new SourceExplorer(context);
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
            var controller = new SourceExplorer(context);
            var result = await controller.View(999);
            Assert.That(result, Is.InstanceOf(typeof(NotFoundResult)));
        }

        [Test]
        public async Task CreateViewResultTest()
        {
            var controller = new SourceExplorer(context);
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

        /*[Test]
        public async Task CreateMissingLinkPdfLinkTest()
        {
            var controller = this.SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", null, null, null, null, SourceTypes.PdfLink);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestResult)));
        }*/

        [Test]
        public async Task CreateMissingLinkVideoLinkTest()
        {
            var controller = this.SetupControllerWithAuthenticatedUser();
            var result = await controller.Create("Title", null, null, null, null, SourceTypes.VideoLink);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestResult)));
        }



        [TestCase(SourceTypes.Pdf, null, null, null, TestName = "Create_WithPdfTypeAndNoFileUpload_ReturnsBadRequest")]
        [TestCase(SourceTypes.Video, null, null, null, TestName = "Create_WithVideoTypeAndNoFileUpload_ReturnsBadRequest")]
        [TestCase(SourceTypes.Image, null, null, null, TestName = "Create_WithImageTypeAndNoFileUpload_ReturnsBadRequest")]
        [TestCase(SourceTypes.ImageLink, null, null, null, TestName = "Create_WithImageLinkTypeAndNoLink_ReturnsBadRequest")]
        public async Task CreateWithTypeSpecificValidation_ReturnsBadRequest(SourceTypes type, IFormFile? pdfUpload, IFormFile? videoUpload, IFormFile? imageUpload)
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
            var result = await controller.Create("Title", "Link", null, null, null, SourceTypes.ImageLink);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
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
            var result = await controller.Note("", 1);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task NoteUserNotAuthenticated_ReturnsUnauthorized()
        {
            var controller = new SourceExplorer(context);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            var result = await controller.Note("Note text", 1);
            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        }

        [Test]
        public async Task NoteValidInput_ReturnsOkResult()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            context.Source.Add(new Source
            { Id = 1, Title = "title", Link = "link", Owner = "kenneth@uwg.com", Type = SourceTypes.Pdf });
            context.SaveChanges();
            var result = await controller.Note("Note text", 1);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task NoteExceptionOccurs_ReturnsBadRequest()
        {
            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.Note("Note text", -1);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        private SourceExplorer SetupControllerWithAuthenticatedUser()
        {
            var controller = new SourceExplorer(context);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "testUserId"),
            }));

            /*var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "testUserId"),
                new Claim(ClaimTypes.Name, "name")
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var user = new ClaimsPrincipal(identity);*/
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
            var source = context.Source.Find(sourceId);
            Assert.IsNull(source);
        }

        [Test]
        public async Task Delete_WhenSourceDoesNotExist_ReturnsBadRequest()
        {
            var nonExistingSourceId = 99;
            var controller = SetupControllerWithAuthenticatedUser();
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
            var source = context.Source.Find(sourceId);
            Assert.IsNull(source);
            var notes = context.Note.Where(n => n.SourceId == sourceId).ToList();
            Assert.IsEmpty(notes);
        }

        [Test]
        public async Task DeleteNote_WithValidNoteId_DeletesNoteAndReturnsOk()
        {
            var noteId = 200;
            context.Note.Add(new Note { Id = noteId, Text = "Test Note", SourceId = 100 });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();
            var result = await controller.DeleteNote(noteId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var note = context.Note.Find(noteId);
            Assert.IsNull(note);
        }

        [Test]
        public async Task DeleteNote_WithInvalidNoteId_ReturnsBadRequest()
        {
            var nonExistingNoteId = 99;
            var controller = SetupControllerWithAuthenticatedUser();

            var result = await controller.DeleteNote(nonExistingNoteId);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task DeleteNote_WhenExceptionOccurs_ReturnsBadRequest()
        {
            var noteId = 201;
            context.Note.Add(new Note { Id = noteId, Text = "Test Note", SourceId = 101 });
            context.SaveChanges();

            var controller = SetupControllerWithAuthenticatedUser();

            var failingContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            failingContext.Setup(x => x.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                          .ThrowsAsync(new Exception("Database error"));
            controller = new SourceExplorer(failingContext.Object);

            var result = await controller.DeleteNote(noteId);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

    }
}
