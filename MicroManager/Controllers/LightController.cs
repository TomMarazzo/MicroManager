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
    public class LightController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LightController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Light
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lights.Include(l => l.InventoryCategory).Include(l => l.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Light/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var light = await _context.Lights
                .Include(l => l.InventoryCategory)
                .Include(l => l.Supplier)
                .FirstOrDefaultAsync(m => m.LightId == id);
            if (light == null)
            {
                return NotFound();
            }

            return View(light);
        }

        // GET: Light/Create
        public IActionResult Create()
        {
            ViewData["InventoryCategory_Id"] = new SelectList(_context.InventoryCategory, "InventoryCategoryId", "InventoryCategoryType");
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Light/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Light light)
        {
            if (ModelState.IsValid)
            {
                light.LightId = Guid.NewGuid();
                _context.Add(light);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryCategory_Id"] = new SelectList(_context.InventoryCategory, "InventoryCategoryId", "InventoryCategoryType", light.InventoryCategory_Id);
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", light.Supplier_Id);
            return View(light);
        }

        // GET: Light/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var light = await _context.Lights.FindAsync(id);
            if (light == null)
            {
                return NotFound();
            }
            ViewData["InventoryCategory_Id"] = new SelectList(_context.InventoryCategory, "InventoryCategoryId", "InventoryCategoryType", light.InventoryCategory_Id);
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", light.Supplier_Id);
            return View(light);
        }

        // POST: Light/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Light light)
        {
            if (id != light.LightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(light);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LightExists(light.LightId))
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
            ViewData["InventoryCategory_Id"] = new SelectList(_context.InventoryCategory, "InventoryCategoryId", "InventoryCategoryType", light.InventoryCategory_Id);
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", light.Supplier_Id);
            return View(light);
        }

        // GET: Light/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var light = await _context.Lights
                .Include(l => l.InventoryCategory)
                .Include(l => l.Supplier)
                .FirstOrDefaultAsync(m => m.LightId == id);
            if (light == null)
            {
                return NotFound();
            }

            return View(light);
        }

        // POST: Light/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var light = await _context.Lights.FindAsync(id);
            if (light != null)
            {
                _context.Lights.Remove(light);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LightExists(Guid id)
        {
            return _context.Lights.Any(e => e.LightId == id);
        }
    }
}
