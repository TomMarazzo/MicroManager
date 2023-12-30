using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MicroManager.Data;
using MicroManager.Models;

namespace MicroManager.Controllers
{
    public class SeedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seed
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seeds.Include(s => s.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seed/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seeds
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SeedId == id);
            if (seed == null)
            {
                return NotFound();
            }

            return View(seed);
        }

        // GET: Seed/Create
        public IActionResult Create()
        {
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Seed/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Seed seed)
        {
            if (ModelState.IsValid)
            {
                seed.SeedId = Guid.NewGuid();
                _context.Add(seed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", seed.Supplier_Id);
            return View(seed);
        }

        // GET: Seed/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seeds.FindAsync(id);
            if (seed == null)
            {
                return NotFound();
            }
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", seed.Supplier_Id);
            return View(seed);
        }

        // POST: Seed/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  Seed seed)
        {
            if (id != seed.SeedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeedExists(seed.SeedId))
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
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", seed.Supplier_Id);
            return View(seed);
        }

        // GET: Seed/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seeds
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SeedId == id);
            if (seed == null)
            {
                return NotFound();
            }

            return View(seed);
        }

        // POST: Seed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var seed = await _context.Seeds.FindAsync(id);
            if (seed != null)
            {
                _context.Seeds.Remove(seed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeedExists(Guid id)
        {
            return _context.Seeds.Any(e => e.SeedId == id);
        }
    }
}
