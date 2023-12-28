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
    public class InventoryCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InventoryCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryCategory.ToListAsync());
        }

        // GET: InventoryCategory/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryCategory = await _context.InventoryCategory
                .FirstOrDefaultAsync(m => m.InventoryCategoryId == id);
            if (inventoryCategory == null)
            {
                return NotFound();
            }

            return View(inventoryCategory);
        }

        // GET: InventoryCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryCategoryId,InventoryCategoryType")] InventoryCategory inventoryCategory)
        {
            if (ModelState.IsValid)
            {
                inventoryCategory.InventoryCategoryId = Guid.NewGuid();
                _context.Add(inventoryCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryCategory);
        }

        // GET: InventoryCategory/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryCategory = await _context.InventoryCategory.FindAsync(id);
            if (inventoryCategory == null)
            {
                return NotFound();
            }
            return View(inventoryCategory);
        }

        // POST: InventoryCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("InventoryCategoryId,InventoryCategoryType")] InventoryCategory inventoryCategory)
        {
            if (id != inventoryCategory.InventoryCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryCategoryExists(inventoryCategory.InventoryCategoryId))
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
            return View(inventoryCategory);
        }

        // GET: InventoryCategory/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryCategory = await _context.InventoryCategory
                .FirstOrDefaultAsync(m => m.InventoryCategoryId == id);
            if (inventoryCategory == null)
            {
                return NotFound();
            }

            return View(inventoryCategory);
        }

        // POST: InventoryCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var inventoryCategory = await _context.InventoryCategory.FindAsync(id);
            if (inventoryCategory != null)
            {
                _context.InventoryCategory.Remove(inventoryCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryCategoryExists(Guid id)
        {
            return _context.InventoryCategory.Any(e => e.InventoryCategoryId == id);
        }
    }
}
