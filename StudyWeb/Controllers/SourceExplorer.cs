using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.Source.FirstOrDefaultAsync(m => m.Id == id);
            if (source == null)
            {
                return NotFound();
            }
            

            return View(source);
            
        }

        /*/// <summary>
        ///   Shows the search results.
        /// </summary>
        /// <param name="SearchName">Name of the search.</param>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> ShowSearchResults(String SearchName)
        {
            return View("Index", await _context.PhonebookEntry.Where(n => n.Name.Contains(SearchName)).ToListAsync());
        }*/


        /*/// <summary>
        ///   Creates this instance.
        /// </summary>
        /// <returns>
        ///   Result
        /// </returns>
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        /// <summary>
        ///   reates the specified phonebook entry.
        /// </summary>
        /// <param name="phonebookEntry">The phonebook entry.</param>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber")] PhonebookEntry phonebookEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phonebookEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phonebookEntry);
        }

        /// <summary>
        ///   Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phonebookEntry = await _context.PhonebookEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phonebookEntry == null)
            {
                return NotFound();
            }

            return View(phonebookEntry);
        }


        /// <summary>
        ///   Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phonebookEntry = await _context.PhonebookEntry.FindAsync(id);
            if (phonebookEntry != null)
            {
                _context.PhonebookEntry.Remove(phonebookEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhonebookEntryExists(int id)
        {
            return _context.PhonebookEntry.Any(e => e.Id == id);
        }*/
    }
}
