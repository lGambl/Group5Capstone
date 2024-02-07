using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudyWeb.Data;
using StudyWeb.Models;

namespace StudyWeb.Controllers;

/// <summary>The Source Explorer Controller</summary>
[Route("[controller]")]
public class SourceExplorer : Controller
{
    #region Data members

    private readonly ApplicationDbContext context;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="SourceExplorer" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public SourceExplorer(ApplicationDbContext context)
    {
        this.context = context;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Indexes this instance.
    /// </summary>
    /// <returns>
    ///     Task
    /// </returns>
    [Authorize]
    public async Task<IActionResult> Index()
    {
        if (Request.Headers["Accept"] == "application/json")
        {
            var owner = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (owner == null)
            {
                return Unauthorized(new { success = false, message = "User is not authenticated." });
            }

            var sources = await this.context.Source.ToListAsync();

            var ownerSources = sources.Where(s => s.Owner == owner).ToList();

            foreach (var source in ownerSources)
            {
                if (source.Type == SourceTypes.Pdf || source.Type == SourceTypes.Video)
                {
                    source.Link = "https://localhost:7240/" + source.Link;
                }
            }

            return Ok(sources);
        }

        return View(await this.context.Source.ToListAsync());
    }

    /// <summary>
    ///     Views the specified identifier source page
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize]
    [Route("View/{id?}")]
    public async Task<IActionResult> View(int? id)
    {
        var source = this.getSource(id);

        if (source == null)
        {
            return NotFound();
        }

        return View(source);
    }

    private Source? getSource(int? id)
    {
        if (id == null)
        {
            return null;
        }

        var source = this.context.Source.FirstOrDefault(m => m.Id == id);

        if (source != null)
        {
            source.Notes = this.context.Note.Where(n => n.SourceId == id).ToList();

            return source;
        }

        return null;
    }

    /// <summary>
    ///     Show view for creating a source
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [Route("Create")]
    public async Task<PartialViewResult> Create()
    {
        return PartialView();
    }

    /// <summary>
    ///     Create a source. This is a endpoint for the form submission and the API.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="link"></param>
    /// <param name="pdfUpload"></param>
    /// <param name="videoUpload"></param>
    /// <param name="imageUpload"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([Bind("Title")] string? title, [Bind("Link")] string? link,
        IFormFile? pdfUpload, IFormFile? videoUpload, IFormFile? imageUpload, [Bind("Type")] SourceTypes? type)
    {
        var user = User.Claims.FirstOrDefault();
        var owner = user?.Value;

        if (owner == null || title == null || type == null)
        {
            return BadRequest();
        }

        switch (type)
        {
            case SourceTypes.Pdf:
                if (pdfUpload == null)
                {
                    return BadRequest();
                }

                if (!await this.saveFile(pdfUpload, title, owner, type))
                {
                    return BadRequest();
                }

                break;
            case SourceTypes.Video:
                if (videoUpload == null)
                {
                    return BadRequest();
                }

                if (!await this.saveFile(videoUpload, title, owner, type))
                {
                    return BadRequest();
                }

                break;
            case SourceTypes.Image:
                if (imageUpload == null)
                {
                    return BadRequest();
                }

                if (!await this.saveFile(imageUpload, title, owner, type))
                {
                    return BadRequest();
                }

                break;
            case SourceTypes.ImageLink:
                if (link == null)
                {
                    return BadRequest();
                }

                if (!await this.addLink(title, owner, link, type))
                {
                    return BadRequest();
                }

                break;
            case SourceTypes.PdfLink:
                await this.addLink(title, owner, link, type);
                break;
            case SourceTypes.VideoLink:
                if (link == null)
                {
                    return BadRequest();
                }

                link = fixYoutubeLink(link);
                if (!await this.addLink(title, owner, link, type))
                {
                    return BadRequest();
                }

                break;
            default:
                return BadRequest();
        }

        if (Request.Headers["Accept"] == "application/json")
        {
            return Ok(new { success = true, message = "Source created successfully." });
        }

        return RedirectToAction("Index", "SourceExplorer");
    }

    private static string fixYoutubeLink(string link)
    {
        if (!link.Contains("youtube.com/watch?v="))
        {
            return link;
        }

        var split = link.Split("=");
        return "https://www.youtube.com/embed/" + split[^1];
    }

    private async Task<bool> saveFile(IFormFile? file, string? title, string? owner, SourceTypes? type)
    {
        var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        if (!Directory.Exists(uploadsFolderPath))
        {
            Directory.CreateDirectory(uploadsFolderPath);
        }

        var uniqueFileName = Guid.NewGuid() + "_" + file?.FileName;
        var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file?.CopyTo(stream);
            }
        }
        catch
        {
            return false;
        }

        var relativePath = "uploads";

        var relativeFilePath = Path.Combine(relativePath, uniqueFileName);

        await this.addLink(title, owner, relativeFilePath, type);

        return true;
    }

    private async Task<bool> addLink(string? title, string? owner, string? link, SourceTypes? type)
    {
        try
        {
            var insertSourceQuery =
                "INSERT INTO Source (title, owner, link, type) VALUES (@title, @owner, @link, @type);";
            SqlParameter[] parameters =
            {
                new("@title", title),
                new("@owner", owner),
                new("@link", link),
                new("@type", type)
            };

            await this.context.Database.ExecuteSqlRawAsync(insertSourceQuery, parameters);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    ///     Route for adding a note to a source
    /// </summary>
    /// <param name="text"></param>
    /// <param name="sourceId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    [Route("Note")]
    public async Task<IActionResult> Note([FromForm] string text, [FromForm] int sourceId)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return BadRequest(new { success = false, message = "Invalid note text or source ID." });
        }

        var owner = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (owner == null)
        {
            return Unauthorized(new { success = false, message = "User is not authenticated." });
        }

        try
        {
            var insertNoteQuery = "INSERT INTO Note (Text, Owner, SourceId) VALUES (@Text, @Owner, @SourceId);";
            SqlParameter[] parameters =
            {
                new("@Text", text),
                new("@Owner", owner),
                new("@SourceId", sourceId)
            };

            await this.context.Database.ExecuteSqlRawAsync(insertNoteQuery, parameters);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

        return Ok(new { success = true, message = "Note added successfully." });
    }

    #endregion
}