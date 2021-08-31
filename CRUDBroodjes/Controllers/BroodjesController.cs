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
    public class BroodjesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BroodjesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Broodjes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Broodje.ToListAsync());
        }

        // GET: Broodjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broodje = await _context.Broodje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broodje == null)
            {
                return NotFound();
            }

            return View(broodje);
        }

        // GET: Broodjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Broodjes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Prijs")] Broodje broodje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(broodje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(broodje);
        }

        // GET: Broodjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broodje = await _context.Broodje.FindAsync(id);
            if (broodje == null)
            {
                return NotFound();
            }
            return View(broodje);
        }

        // POST: Broodjes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Prijs")] Broodje broodje)
        {
            if (id != broodje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(broodje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BroodjeExists(broodje.Id))
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
            return View(broodje);
        }

        // GET: Broodjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broodje = await _context.Broodje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broodje == null)
            {
                return NotFound();
            }

            return View(broodje);
        }

        // POST: Broodjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var broodje = await _context.Broodje.FindAsync(id);
            _context.Broodje.Remove(broodje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BroodjeExists(int id)
        {
            return _context.Broodje.Any(e => e.Id == id);
        }
    }
}
