using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BestPhonebookApp.Data;
using BestPhonebookApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace BestPhonebookApp.Controllers
{

    /// <summary>The Phonebook Entries Controller</summary>
    public class PhonebookEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;


        /// <summary>
        ///   Initializes a new instance of the <see cref="PhonebookEntriesController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PhonebookEntriesController(ApplicationDbContext context)
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
            return View(await _context.PhonebookEntry.ToListAsync());
        }


        /// <summary>
        ///   Shows the search form.
        /// </summary>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }


        /// <summary>
        ///   Shows the search results.
        /// </summary>
        /// <param name="SearchName">Name of the search.</param>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        public async Task<IActionResult> ShowSearchResults(String SearchName)
        {
            return View("Index", await _context.PhonebookEntry.Where(n => n.Name.Contains(SearchName)).ToListAsync());
        }


        /// <summary>
        ///   Details the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Task
        /// </returns>
        public async Task<IActionResult> Details(int? id)
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
        ///   Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phonebookEntry = await _context.PhonebookEntry.FindAsync(id);
            if (phonebookEntry == null)
            {
                return NotFound();
            }
            return View(phonebookEntry);
        }


        /// <summary>
        ///   Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="phonebookEntry">The phonebook entry.</param>
        /// <returns>
        ///   Task
        /// </returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber")] PhonebookEntry phonebookEntry)
        {
            if (id != phonebookEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phonebookEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhonebookEntryExists(phonebookEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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
        }
    }
}
