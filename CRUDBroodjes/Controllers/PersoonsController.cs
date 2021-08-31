using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDBroodjes.Data;
using CRUDBroodjes.Models;

namespace CRUDBroodjes.Controllers
{
    public class PersoonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersoonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Persoons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persoon.ToListAsync());
        }

        // GET: Persoons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoon = await _context.Persoon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoon == null)
            {
                return NotFound();
            }

            return View(persoon);
        }

        // GET: Persoons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persoons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoorNaam,AchterNaam,Geslacht,Geboortedatum,TotaalPrijs")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persoon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persoon);
        }

        // GET: Persoons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoon = await _context.Persoon.FindAsync(id);
            if (persoon == null)
            {
                return NotFound();
            }
            return View(persoon);
        }

        // POST: Persoons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoorNaam,AchterNaam,Geslacht,Geboortedatum,TotaalPrijs")] Persoon persoon)
        {
            if (id != persoon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersoonExists(persoon.Id))
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
            return View(persoon);
        }

        // GET: Persoons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoon = await _context.Persoon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoon == null)
            {
                return NotFound();
            }

            return View(persoon);
        }

        // POST: Persoons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persoon = await _context.Persoon.FindAsync(id);
            _context.Persoon.Remove(persoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoonExists(int id)
        {
            return _context.Persoon.Any(e => e.Id == id);
        }
    }
}
