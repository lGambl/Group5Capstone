using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudyWeb.Data;
using StudyWeb.Models;

namespace StudyWeb.Controllers;

/// <summary>The Source Explorer Controller</summary>
[Route("[controller]")]
public class SourceExplorer : Controller
{
    #region Data members

    private readonly ApplicationDbContext context;
    private readonly IDatabaseService databaseService;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="SourceExplorer" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param service="service">The service.</param>
    public SourceExplorer(ApplicationDbContext context, IDatabaseService service)
    {
        this.context = context;
        this.databaseService = service;
        
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Shows the index page for the source explorer
    /// </summary>
    /// <returns>
    ///     A page with all the sources.
    /// </returns>
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var owner = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (owner == null)
        {
            return Unauthorized(new { success = false, message = "User is not authenticated." });
        }

        var sources = await this.context.Source.ToListAsync();

        var ownerSources = sources.Where(s => s.Owner == owner).ToList();

        if (Request.Headers["Accept"] == "application/json")
        {
            

            foreach (var source in ownerSources)
            {
                if (source.Type is SourceTypes.Pdf or SourceTypes.Video)
                {
                    source.Link = "https://localhost:7240/" + source.Link;
                }
            }

            return Ok(ownerSources);
        }



        return View(ownerSources);
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

    /// <summary>
    ///     Adds the tag.
    /// </summary>
    /// <param name="noteId">The note identifier.</param>
    /// <param name="tagName">Name of the tag.</param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    [Route("AddTag")]
    public async Task<IActionResult> AddTag([FromForm] int noteId, [FromForm] string tagName)
    {
        if (string.IsNullOrWhiteSpace(tagName))
        {
            return BadRequest(new { success = false, message = "Invalid tag name." });
        }

        var owner = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (owner == null)
        {
            return Unauthorized(new { success = false, message = "User is not authenticated." });
        }

        try
        {
            var tagList = new List<string> { tagName };
            await this.addTagsIfNew(tagList);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

        var tag = this.context.Tags.FirstOrDefault(t => t.Name == tagName);

        if (this.tagAlreadyAdded(tag, noteId))
        {
            return BadRequest(new { success = false, message = "Tag already added." });
        }

        try
        {
            var insertNoteTagQuery = "INSERT INTO NoteTags (NoteId, TagId) VALUES (@NoteId, @TagId);";
            SqlParameter[] parameters =
            {
                new("@NoteId", noteId),
                new("@TagId", tag.Id)
            };

            await this.databaseService.ExecuteSqlRawAsync(insertNoteTagQuery, parameters);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

        return Ok(new { success = true, message = "Tag added successfully." });
    }

    private bool tagAlreadyAdded(Tags tag, int noteId)
    {
        var noteTagsEntry = this.context.NoteTags.FirstOrDefault(nt => nt.TagId == tag.Id && nt.NoteId == noteId);
        return noteTagsEntry != null;
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
            this.loadNotes(source);
            return source;
        }

        return null;
    }

    private void loadNotes(Source source)
    {
        source.Notes = this.context.Note.Where(n => n.SourceId == source.Id).ToList();
        foreach (var note in source.Notes)
        {
            this.getNoteTags(note);
        }
    }

    private void getNoteTags(Note note)
    {
        note.Tags = this.queryTags(note.Id);
    }

    private IList<Tags> queryTags(int noteId)
    {
        var tagIds = this.context.NoteTags.Where(nt => nt.NoteId == noteId).Select(nt => nt.TagId).ToList();
        var tags = this.context.Tags.ToList();
        return tags.Where(t => tagIds.Contains(t.Id)).ToList();
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
    ///     Create a source. This is an endpoint for the form submission and the API.
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
    /// <param name="tags"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    [Route("Note")]
    public async Task<IActionResult> Note([FromForm] string text, [FromForm] int sourceId, [FromForm] string tags)
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
            if (this.noTags(tags))
            {
                var insertNoteQuery = "INSERT INTO Note (Text, Owner, SourceId) VALUES (@Text, @Owner, @SourceId);";
                object[] parameters =
                [
                    new SqlParameter("@Text", text),
                    new SqlParameter("@Owner", owner),
                    new SqlParameter("@SourceId", sourceId)
                ];
                await this.databaseService.ExecuteSqlRawAsync(insertNoteQuery, parameters);
            }
            else
            {
                await this.addNoteWithTags(text, owner, sourceId, tags);
            }
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

        return Ok(new { success = true, message = "Note added successfully." });
    }

    private bool noTags(string tags)
    {
        if (!string.IsNullOrWhiteSpace(tags))
        {
            if (tags.Contains(','))
            {
                return false;
            }
        }

        return true;
    }

    private async Task addNoteWithTags(string text, string owner, int sourceId, string tags)
    {
        var insertNoteQuery = "INSERT INTO Note (Text, Owner, SourceId) VALUES (@Text, @Owner, @SourceId);";
        SqlParameter[] parameters =
        {
            new("@Text", text),
            new("@Owner", owner),
            new("@SourceId", sourceId)
        };
        var noteId = await this.databaseService.ExecuteSqlRawAsync(insertNoteQuery, parameters);

        var note =
            this.context.Note.FirstOrDefault(n => n.Text == text && n.Owner == owner && n.SourceId == sourceId) ??
            throw new Exception();

        var tagList = tags.Split(',');
        await this.addTagsIfNew(tagList);
        await this.addNoteTags(note, tagList);
    }

    private async Task addNoteTags(Note note, IEnumerable<string> tagList)
    {
        foreach (var tag in tagList)
        {
            if (!tag.IsNullOrEmpty())
            {
                var tagId = this.context.Tags.FirstOrDefault(t => t.Name == tag)?.Id ?? throw new Exception();
                var insertNoteTagQuery = "INSERT INTO NoteTags (NoteId, TagId) VALUES (@NoteId, @TagId);";
                SqlParameter[] parameters =
                {
                    new("@NoteId", note.Id),
                    new("@TagId", tagId)
                };
                await this.databaseService.ExecuteSqlRawAsync(insertNoteTagQuery, parameters);
            }
        }
    }

    private async Task addTagsIfNew(IEnumerable<string> tagList)
    {
        foreach (var tag in tagList)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                continue;
            }

            var tagExists = this.context.Tags.FirstOrDefault(t => t.Name == tag);
            if (tagExists == null)
            {
                var insertTagQuery = "INSERT INTO Tags (Name) VALUES (@Name);";
                SqlParameter[] parameters =
                {
                    new("@Name", tag)
                };
                await this.databaseService.ExecuteSqlRawAsync(insertTagQuery, parameters);
            }
        }
    }

    /// <summary>
    ///     Deletes the specified source identifier.
    /// </summary>
    /// <param name="sourceId">The source identifier.</param>
    /// <returns>
    ///     Success message if successful, bad request if unsuccessful.
    /// </returns>
    [Authorize]
    [HttpDelete]
    [Route("Delete/{sourceId}")]
    public async Task<IActionResult> Delete(int sourceId)
    {
        if (sourceId < 0)
        {
            return BadRequest(new { success = false, message = "Source Id not found. " });
        }

        var notesDeletedResult = this.deleteSourceNotes(sourceId);
        if (notesDeletedResult.Result is OkObjectResult)
        {
            try
            {
                const string deleteSourceQuery = "DELETE FROM source WHERE Id = @Id";
                var parameter = new SqlParameter("@Id", sourceId);
                await this.databaseService.ExecuteSqlRawAsync(deleteSourceQuery, parameter);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

            return Ok(new { success = true, message = "Source deleted successfully." });
        }

        return BadRequest(new { success = false, message = "Deletion Failed." });
    }

    private async Task<IActionResult> deleteSourceNotes(int sourceId)
    {
        var sourceNotes = this.context.Note.Where(n => n.SourceId == sourceId).ToListAsync();
        if (sourceNotes.Result.Count > 0)
        {
            try
            {
                foreach (var currNote in sourceNotes.Result)
                {
                    const string deleteNoteQuery = "DELETE FROM note WHERE Id = @Id";
                    var parameter = new SqlParameter("@Id", currNote.Id);
                    await this.databaseService.ExecuteSqlRawAsync(deleteNoteQuery, parameter);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(new { success = true, message = "Notes removed successfully." });
        }

        return Ok(new { success = true, message = "The source has no notes to delete." });
    }

    /// <summary>
    ///     Deletes the note.
    /// </summary>
    /// <param name="noteId">The note identifier.</param>
    /// <returns>
    ///     Ok, if the note was removed successfully.
    ///     BadRequest if the note was not deleted.
    /// </returns>
    [Authorize]
    [HttpDelete]
    [Route("DeleteNote/{noteId}")]
    public async Task<IActionResult> DeleteNote(int noteId)
    {
        if (noteId < 0)
        {
            return BadRequest(new { success = false, message = "Note Id not found. " });
        }

        try
        {
            const string deleteSourceQuery = "DELETE FROM note WHERE Id = @Id";
            var parameter = new SqlParameter("@Id", noteId);
            await this.databaseService.ExecuteSqlRawAsync(deleteSourceQuery, parameter);
            await this.deleteNoteTags(noteId);
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }

        return Ok(new { success = true, message = "Note deleted successfully." });
    }

    private async Task deleteNoteTags(int noteId)
    {
        const string deleteNoteTagsQuery = "DELETE FROM NoteTags WHERE NoteId = @NoteId";

        var parameter = new SqlParameter("@NoteId", noteId);
        await this.databaseService.ExecuteSqlRawAsync(deleteNoteTagsQuery, parameter);
    }

    /// <summary>
    ///     Searches the tags.
    /// </summary>
    /// <param name="tags">The tags.</param>
    /// <returns>
    ///     Ok & a list of sources, if successful.
    ///     BadRequest if unsuccessful.
    /// </returns>
    [Authorize]
    [Route("SearchTags")]
    public async Task<IActionResult> SearchTags([FromBody] IEnumerable<string> tags)
    {
        if (tags == null || !tags.Any())
        {
            return BadRequest(new { success = false, message = "Tag list is empty." });
        }

        try
        {
            var tagPlaceholders = string.Join(", ", tags.Select((tag, index) => $"@tag{index}"));
            var searchTagsQuery = $"SELECT DISTINCT Source.Id, Source.Link, Source.Title, Source.Type, Source.Owner " +
                                  $"FROM Tags " +
                                  $"JOIN NoteTags ON Tags.Id = NoteTags.TagId " +
                                  $"JOIN Note ON NoteTags.NoteId = Note.Id " +
                                  $"JOIN Source ON Note.SourceId = Source.Id " +
                                  $"WHERE Tags.Name IN ({tagPlaceholders})";

            var parameters = tags.Select((tag, index) => new SqlParameter($"tag{index}", tag)).ToArray();

            var sources = await this.context.Source
                .FromSqlRaw(searchTagsQuery, parameters)
                .ToListAsync();

            if (sources == null || sources.Count == 0)
            {
                return NotFound(new { success = false, message = "No sources found for the given tags." });
            }

            return Ok(sources);
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// Deletes the NoteTag entries for the given tagIds associated with the noteId.
    /// </summary>
    /// <param name="noteId">The id of the note.</param>
    /// <param name="tagIds">The ids of the tags to delete.</param>
    /// <returns>Ok if successful, BadRequest if an exception occurs, and Unauthorized if user is not authorized.</returns>
    [Authorize]
    [HttpDelete]
    [Route("DeleteNoteTags/{noteId}")]
    public async Task<IActionResult> DeleteNoteTags(int noteId, IEnumerable<int> tagIds)
    {
        if (noteId < 0 || tagIds == null || !tagIds.Any())
        {
            return BadRequest(new { success = false, message = "Note Id or Tag Ids not found. " });
        }

        var owner = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (owner == null)
        {
            return Unauthorized(new { success = false, message = "User is not authenticated." });
        }

        try
        {
            foreach (var tagId in tagIds)
            {
                const string deleteNoteTagsQuery = "DELETE FROM NoteTags WHERE NoteId = @NoteId AND TagId = @TagId";

                var parameters = new[]
                {
                    new SqlParameter("@NoteId", noteId),
                    new SqlParameter("@TagId", tagId)
                };

                await this.databaseService.ExecuteSqlRawAsync(deleteNoteTagsQuery, parameters);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }

        return Ok(new { success = true, message = "Note tags deleted successfully." });
    }

    /// <summary>
    ///   Edits the note.
    /// </summary>
    /// <param name="noteId">The note identifier.</param>
    /// <param name="newText">The new text.</param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    [Route("EditNote")]
    public async Task<IActionResult> EditNote([FromForm] int noteId, [FromForm] string newText)
    {
        if (string.IsNullOrWhiteSpace(newText))
        {
            return BadRequest(new { success = false, message = "New text for the note is required." });
        }

        var owner = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (owner == null)
        {
            return Unauthorized(new { success = false, message = "User is not authenticated." });
        }

        var noteExists = await this.context.Note.AnyAsync(n => n.Id == noteId && n.Owner == owner);
        if (!noteExists)
        {
            return NotFound(new { success = false, message = "Note not found or you do not have permission to edit it." });
        }

        try
        {
            var updateNoteTextQuery = "UPDATE Note SET Text = @newText WHERE Id = @noteId AND Owner = @owner";
            var parameters = new[]
            {
                new SqlParameter("@newText", newText),
                new SqlParameter("@noteId", noteId),
                new SqlParameter("@owner", owner)
            };

            await this.databaseService.ExecuteSqlRawAsync(updateNoteTextQuery, parameters);
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = $"An error occurred while updating the note: {ex.Message}" });
        }

        return Ok(new { success = true, message = "Note updated successfully." });
    }

    #endregion
}