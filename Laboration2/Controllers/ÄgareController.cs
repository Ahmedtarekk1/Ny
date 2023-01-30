using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboration2.Models;

namespace Laboration2.Controllers
{
    public class ÄgareController : Controller
    {
        private readonly HusContext _context;

        public ÄgareController(HusContext context)
        {
            _context = context;
        }

        // GET: Ägare
        public async Task<IActionResult> Index()
        {
            var husContext = _context.Ägare.Include(ä => ä.Hustyp);
            return View(await husContext.ToListAsync());
        }

        // GET: Ägare/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ägare == null)
            {
                return NotFound();
            }

            var ägare = await _context.Ägare
                .Include(ä => ä.Hustyp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ägare == null)
            {
                return NotFound();
            }

            return View(ägare);
        }

        // GET: Ägare/Create
        public IActionResult Create()
        {
            ViewData["HustypId"] = new SelectList(_context.Hustyp, "Id", "Id");
            return View();
        }

        // POST: Ägare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn,HustypId")] Ägare ägare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ägare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HustypId"] = new SelectList(_context.Hustyp, "Id", "Id", ägare.HustypId);
            return View(ägare);
        }

        // GET: Ägare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ägare == null)
            {
                return NotFound();
            }

            var ägare = await _context.Ägare.FindAsync(id);
            if (ägare == null)
            {
                return NotFound();
            }
            ViewData["HustypId"] = new SelectList(_context.Hustyp, "Id", "Id", ägare.HustypId);
            return View(ägare);
        }

        // POST: Ägare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn,HustypId")] Ägare ägare)
        {
            if (id != ägare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ägare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ÄgareExists(ägare.Id))
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
            ViewData["HustypId"] = new SelectList(_context.Hustyp, "Id", "Id", ägare.HustypId);
            return View(ägare);
        }

        // GET: Ägare/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ägare == null)
            {
                return NotFound();
            }

            var ägare = await _context.Ägare
                .Include(ä => ä.Hustyp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ägare == null)
            {
                return NotFound();
            }

            return View(ägare);
        }

        // POST: Ägare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ägare == null)
            {
                return Problem("Entity set 'HusContext.Ägare'  is null.");
            }
            var ägare = await _context.Ägare.FindAsync(id);
            if (ägare != null)
            {
                _context.Ägare.Remove(ägare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ÄgareExists(int id)
        {
          return (_context.Ägare?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
