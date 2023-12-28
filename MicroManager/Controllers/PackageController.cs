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
    public class PackageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackageController(ApplicationDbContext context)
        {
            _context = context;
        }

        //***********Report***********
        public class PackageViewModel
        {
            public List<Package> Packages { get; set; }
            public double PlasticTotal
            {
                get
                {
                    double Total = 0;
                    foreach (var items in Packages)
                    {
                        if (items.PackageType == "Plastic")
                        {
                            Total += items.Total;
                        }
                    }
                    return Total;
                }
            }
            public double PaperTotal
            {
                get
                {
                    double Total = 0;
                    foreach (var items in Packages)
                    {
                        if (items.PackageType == "Paper")
                        {
                            Total += items.Total;
                        }
                    }
                    return Total;
                }
            }
            public double PlasticPaperTotal
            {
                get
                {
                    return PaperTotal + PlasticTotal;
                }
            }
        }

        // GET: Package  ****************Changes for Report*********
        public async Task<IActionResult> PackageIndex()
        {
            PackageViewModel packageViewModel = new PackageViewModel();

            packageViewModel.Packages = await _context.Packages.Include(p => p.Supplier).ToListAsync();

            return View(packageViewModel);
        }

        // GET: Package/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // GET: Package/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            ViewData["ProductSizeId"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size");
            return View();
        }

        // POST: Package/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,Supplier_Id,Date,PackageType,PackSize,OrderQty,Price,Tax")] Package package)
        {
            if (ModelState.IsValid)
            {
                package.PackageId = Guid.NewGuid();
                _context.Add(package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PackageIndex));
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", package.Supplier_Id);
            ViewData["ProductSizeId"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size");
            return View(package);
        }

        // GET: Package/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", package.Supplier_Id);
            ViewData["ProductSizeId"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size");
            return View(package);
        }

        // POST: Package/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PackageId,Supplier_Id,Date,PackageType,PackSize,OrderQty,Price,Tax")] Package package)
        {
            if (id != package.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(package);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(package.PackageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(PackageIndex));
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", package.Supplier_Id);
            ViewData["ProductSizeId"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size");

            return View(package);
        }

        // GET: Package/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PackageIndex));
        }

        private bool PackageExists(Guid id)
        {
            return _context.Packages.Any(e => e.PackageId == id);
        }
    }
}