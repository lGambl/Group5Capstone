using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudyWeb.Data;
using StudyWeb.Models;

namespace StudyWeb.Controllers
{

    /// <summary>The Source Explorer Controller</summary>
    [Route("[controller]")]
    public class SourceExplorer : Controller
    {
        private readonly ApplicationDbContext _context;


        /// <summary>
        ///   Initializes a new instance of the <see cref="SourceExplorer" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SourceExplorer(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        ///   Indexes this instance.
        /// </summary>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Source.ToListAsync());
        }

        [Authorize]
        [Route("View/{id?}")]
        public async Task<IActionResult> View(int? id)
        {
            
            var source = RetreiveSource(id);

            if (source == null)
            {
                return NotFound();
            }

            return View(source);
            
        }

        [Authorize]
        [HttpGet]
        [Route("Source/{id?}")]
        public Source? GetSource(int? id)
        {

            var source = RetreiveSource(id);
            if (source == null)
            {
                return null;
            }

            return source;
            
        }

        private Source? RetreiveSource(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var source = _context.Source.FirstOrDefault(m => m.Id == id);

            if (source == null)
            {
                return null;
            }
            

            return source;
        }

        [Authorize]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Title")] string title, [Bind("Link")] string link, IFormFile pdfUpload, IFormFile videoUpload, [Bind("Type")] SourceTypes type)
        {
            var owner = User.Claims.FirstOrDefault().Value;
            

            if (owner == null || title == null || type == null )
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

                    if (!await saveFile(pdfUpload, title, owner, type))
                    {
                        return BadRequest();
                    }
                    break;
                case SourceTypes.Video:
                    if (videoUpload == null)
                    {
                        return BadRequest();
                    }

                    if (!await saveFile(videoUpload, title, owner, type))
                    {
                        return BadRequest();
                    }
                    break;
                case SourceTypes.PdfLink:
                    await this.AddLink(title, owner, link, type);
                    break;
                case SourceTypes.VideoLink:
                    if (link == null)
                    {
                        return BadRequest();
                    }

                    if (!await this.AddLink(title, owner, link, type))
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

            return RedirectToAction("Index","SourceExplorer");

        }

        private async Task<bool> saveFile(IFormFile file,string title, string owner, SourceTypes type)
        {
            

            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            // Ensure the upload folder exists
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            string uniqueFileName = Guid.NewGuid() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                return false;
            }

            string relativePath = "uploads";

            var relativeFilePath = Path.Combine(relativePath, uniqueFileName);

            await this.AddLink(title, owner, relativeFilePath, type);

            return true;
        }

        private async Task<bool> AddLink(string title, string owner, string link, SourceTypes type)
        {
            try
            {
                var insertSourceQuery = "INSERT INTO Source (title, owner, link, type) VALUES (@title, @owner, @link, @type);";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@title", title),
                    new SqlParameter("@owner", owner),
                    new SqlParameter("@link", link),
                    new SqlParameter("@type", type)
                };

                await _context.Database.ExecuteSqlRawAsync(insertSourceQuery, parameters);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your requirement
                // For debugging: throw; or return false;
                return false;
            }
        }

        public async Task<IActionResult> AddNote(string Note)
        {
            return BadRequest();
        }
    }
}
