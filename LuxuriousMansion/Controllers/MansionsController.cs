using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxuriousMansion.Data;
using LuxuriousMansion.Models;

namespace LuxuriousMansion.Controllers
{
    public class MansionsController : Controller
    {
        private readonly LuxuriousMansionContext _context;

        public MansionsController(LuxuriousMansionContext context)
        {
            _context = context;
        }

        // GET: Mansions
        public async Task<IActionResult> Index(string searchString)
        {
              return _context.Mansion != null ? 
                          View(await _context.Mansion.ToListAsync()) :
                          Problem("Entity set 'LuxuriousMansionContext.Mansion' is null.");
        }

        // GET: Mansions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mansion == null)
            {
                return NotFound();
            }

            var mansion = await _context.Mansion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mansion == null)
            {
                return NotFound();
            }

            return View(mansion);
        }

        // GET: Mansions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mansions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,CreatedDate")] Mansion mansion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mansion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mansion);
        }

        // GET: Mansions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mansion == null)
            {
                return NotFound();
            }

            var mansion = await _context.Mansion.FindAsync(id);
            if (mansion == null)
            {
                return NotFound();
            }
            return View(mansion);
        }

        // POST: Mansions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,CreatedDate")] Mansion mansion)
        {
            if (id != mansion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mansion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MansionExists(mansion.Id))
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
            return View(mansion);
        }

        // GET: Mansions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mansion == null)
            {
                return NotFound();
            }

            var mansion = await _context.Mansion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mansion == null)
            {
                return NotFound();
            }

            return View(mansion);
        }

        // POST: Mansions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mansion == null)
            {
                return Problem("Entity set 'LuxuriousMansionContext.Mansion'  is null.");
            }
            var mansion = await _context.Mansion.FindAsync(id);
            if (mansion != null)
            {
                _context.Mansion.Remove(mansion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MansionExists(int id)
        {
          return (_context.Mansion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
