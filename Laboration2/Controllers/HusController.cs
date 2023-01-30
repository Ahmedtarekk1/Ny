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
    public class HusController : Controller
    {
        private readonly HusContext _context;

        public HusController(HusContext context)
        {
            _context = context;
        }

        // GET: Hus
        public async Task<IActionResult> Index()
        {
              return _context.Hustyp != null ? 
                          View(await _context.Hustyp.ToListAsync()) :
                          Problem("Entity set 'HusContext.Hustyp'  is null.");
        }

        // GET: Hus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hustyp == null)
            {
                return NotFound();
            }

            var hustyp = await _context.Hustyp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hustyp == null)
            {
                return NotFound();
            }

            return View(hustyp);
        }

        // GET: Hus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hustypen,Bildlänk")] Hustyp hustyp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hustyp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hustyp);
        }

        // GET: Hus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hustyp == null)
            {
                return NotFound();
            }

            var hustyp = await _context.Hustyp.FindAsync(id);
            if (hustyp == null)
            {
                return NotFound();
            }
            return View(hustyp);
        }

        // POST: Hus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hustypen,Bildlänk")] Hustyp hustyp)
        {
            if (id != hustyp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hustyp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HustypExists(hustyp.Id))
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
            return View(hustyp);
        }

        // GET: Hus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hustyp == null)
            {
                return NotFound();
            }

            var hustyp = await _context.Hustyp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hustyp == null)
            {
                return NotFound();
            }

            return View(hustyp);
        }

        // POST: Hus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hustyp == null)
            {
                return Problem("Entity set 'HusContext.Hustyp'  is null.");
            }
            var hustyp = await _context.Hustyp.FindAsync(id);
            if (hustyp != null)
            {
                _context.Hustyp.Remove(hustyp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HustypExists(int id)
        {
          return (_context.Hustyp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
