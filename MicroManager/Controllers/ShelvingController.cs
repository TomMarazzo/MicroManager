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
    public class ShelvingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShelvingController(ApplicationDbContext context)
        {
            _context = context;
        }

        //***********Report***********

        public class ShelvingViewModel
        {
            public List<Shelving> Shelving { get; set; }
            public double TotalPurchasePrice
            {
                get
                {
                    double TotalPrice = 0;
                    foreach (var items in Shelving)
                    {
                        TotalPrice += items.TotalPrice;
                    }
                    return TotalPrice;
                }
            }
            public double TotalSpaces
            {
                get
                {
                    int TotalSpaces = 0;
                    foreach (var items in Shelving)
                    {
                         TotalSpaces += items.TotalGrowSpaces;
                    }
                    return TotalSpaces;
                }
            }
        }

        // GET: Shelving
        public async Task<IActionResult> Index()
        {
            ShelvingViewModel shelvingViewModel = new ShelvingViewModel();

            shelvingViewModel.Shelving = await _context.Shelving.Include(p => p.Supplier).ToListAsync();

            return View(shelvingViewModel);
        }

        // GET: Shelving/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelving = await _context.Shelving
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.ShelvingId == id);
            if (shelving == null)
            {
                return NotFound();
            }

            return View(shelving);
        }


        // GET: Shelving/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Shelving/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShelvingId,SupplierId,Date,Qty,Price,Tax,Row,Column")] Shelving shelving)
        {
            if (ModelState.IsValid)
            {
                shelving.ShelvingId = Guid.NewGuid();
                _context.Add(shelving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", shelving.SupplierId);
            return View(shelving);
        }

        // GET: Shelving/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelving = await _context.Shelving.FindAsync(id);
            if (shelving == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", shelving.SupplierId);
            return View(shelving);
        }

        // POST: Shelving/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ShelvingId,SupplierId,Date,Qty,Price,Tax,Row,Column")] Shelving shelving)
        {
            if (id != shelving.ShelvingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelvingExists(shelving.ShelvingId))
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
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", shelving.SupplierId);
            return View(shelving);
        }

        // GET: Shelving/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelving = await _context.Shelving
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.ShelvingId == id);
            if (shelving == null)
            {
                return NotFound();
            }

            return View(shelving);
        }

        // POST: Shelving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var shelving = await _context.Shelving.FindAsync(id);
            if (shelving != null)
            {
                _context.Shelving.Remove(shelving);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelvingExists(Guid id)
        {
            return _context.Shelving.Any(e => e.ShelvingId == id);
        }
    }
}

