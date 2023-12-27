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
    public class TrayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrayController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: Tray
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trays.Include(t => t.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tray/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tray = await _context.Trays
                .Include(t => t.Supplier)
                .FirstOrDefaultAsync(m => m.TrayId == id);
            if (tray == null)
            {
                return NotFound();
            }

            return View(tray);
        }

        // GET: Tray/Create
        public IActionResult Create()
        {
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Tray/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrayId,Supplier_Id,Date,Type,Qty,Qty_pack,NoTrays,Price,Tax")] Tray tray)
        {
            if (ModelState.IsValid)
            {
                tray.TrayId = Guid.NewGuid();
                _context.Add(tray);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", tray.Supplier_Id);
            return View(tray);
        }

        // GET: Tray/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tray = await _context.Trays.FindAsync(id);
            if (tray == null)
            {
                return NotFound();
            }
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", tray.Supplier_Id);
            return View(tray);
        }

        // POST: Tray/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TrayId,Supplier_Id,Date,Type,Qty,Qty_pack,NoTrays,Price,Tax")] Tray tray)
        {
            if (id != tray.TrayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tray);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrayExists(tray.TrayId))
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
            ViewData["Supplier_Id"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", tray.Supplier_Id);
            return View(tray);
        }

        // GET: Tray/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tray = await _context.Trays
                .Include(t => t.Supplier)
                .FirstOrDefaultAsync(m => m.TrayId == id);
            if (tray == null)
            {
                return NotFound();
            }

            return View(tray);
        }

        // POST: Tray/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tray = await _context.Trays.FindAsync(id);
            if (tray != null)
            {
                _context.Trays.Remove(tray);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrayExists(Guid id)
        {
            return _context.Trays.Any(e => e.TrayId == id);
        }
    }
}
