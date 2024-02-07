using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using StudyWeb.Controllers;
using StudyWeb.Data;
using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.controller;

[TestFixture]
public class SourceExplorerTest
{
    private Mock<ApplicationDbContext>? mockContext;
    private Mock<DbSet<Source>>? mockSet;
    private SourceExplorer? controller;

    [SetUp]
    public void Setup()
    {
        this.mockContext = new Mock<ApplicationDbContext>();
        var sources = new List<Source>
        {
            new() { Id = 1, Owner = "test", Type = SourceTypes.Pdf, Link = "test.pdf", Notes = new List<Note>()},
            new() { Id = 2, Owner = "test", Type = SourceTypes.Video, Link = "test.mp4", Notes = new List<Note>()}
        }.AsQueryable();
        var notes = new List<Note>
        {
            new() { Id = 1, Owner = "test", SourceId = 1, Text = "test note 1" },
            new() { Id = 2, Owner = "test", SourceId = 1, Text = "test note 2" },
        };
        var mockNotes = notes.AsQueryable();
        var mockSet = sources.AsAsyncDbSet();
        this.mockContext.Setup(m => m.Source).Returns(mockSet);
        this.mockContext.Setup(m => m.Note).Returns(mockNotes.AsAsyncDbSet());
        this.controller = new SourceExplorer(this.mockContext.Object);
    }

    [Test]
    public void TestSourceExplorerConstructor()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.controller, Is.Not.Null);
            Assert.That(this.controller, Is.InstanceOf<SourceExplorer>());
        });
    }

    [Test]
    public async Task Index_UnauthorizedAccess_ReturnsUnauthorized()
    {
        var mockSet = new Mock<DbSet<Source>>();
        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Source).Returns(mockSet.Object);

        var controller = new SourceExplorer(mockContext.Object);
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Accept = "application/json";
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        controller.ControllerContext.HttpContext.User = claimsPrincipal;

        var result = await controller.Index();

        Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
    }

    [Test]
    public async Task Index_AuthorizedAccess_ReturnsOk()
    {
        var controller = new SourceExplorer(this.mockContext!.Object);
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Accept = "application/json";
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, "test")
        }));
        controller.ControllerContext.HttpContext.User = claimsPrincipal;

        var result = await controller.Index();
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.Value, Is.InstanceOf<List<Source>>());
        });
    }

    [Test]
    public async Task Index_AuthorizedAccess_ReturnsView()
    {
        var controller = new SourceExplorer(this.mockContext!.Object);
        var httpContext = new DefaultHttpContext();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, "test")
        }));
        controller.ControllerContext.HttpContext.User = claimsPrincipal;

        var result = await controller.Index();
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That((result as ViewResult)?.Model, Is.InstanceOf<List<Source>>());
        });
    }

    [Test]
    public async Task ViewId_ReturnsNotFound()
    {
        var controller = new SourceExplorer(this.mockContext!.Object);
        var result = await controller.View(3);
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public async Task ViewId_ReturnsViewSource()
    {
        var controller = new SourceExplorer(this.mockContext!.Object);
        var result = await controller.View(1);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That((result as ViewResult)?.Model, Is.InstanceOf<Source>());
        });
    }


    [Test]
    public async Task ViewId_NullId_ReturnsNotFound()
    {
        var controller = new SourceExplorer(this.mockContext!.Object);
        var result = await controller.View(null);
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public async Task Create_ReturnsPartialView()
    {
        var controller = new SourceExplorer(this.mockContext!.Object);
        var result = await controller.Create();
        Assert.That(result, Is.InstanceOf<PartialViewResult>());
    }


}