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
    public class GrowMediaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrowMediaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GrowMedia
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GrowMedias.Include(g => g.GrowMediaType).Include(g => g.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GrowMedia/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growMedia = await _context.GrowMedias
                .Include(g => g.GrowMediaType)
                .Include(g => g.Supplier)
                .FirstOrDefaultAsync(m => m.GrowMediaId == id);
            if (growMedia == null)
            {
                return NotFound();
            }

            return View(growMedia);
        }

        // GET: GrowMedia/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.GrowMediaTypes, "GMTypeId", "GMTypeId");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return View();
        }

        // POST: GrowMedia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrowMediaId,SupplierId,GMTypeId,Date,Type,Volume,OrderQty,Price,Tax")] GrowMedia growMedia)
        {
            if (ModelState.IsValid)
            {
                growMedia.GrowMediaId = Guid.NewGuid();
                _context.Add(growMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.GrowMediaTypes, "GMTypeId", "GMTypeId", growMedia.SupplierId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", growMedia.SupplierId);
            return View(growMedia);
        }

        // GET: GrowMedia/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growMedia = await _context.GrowMedias.FindAsync(id);
            if (growMedia == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.GrowMediaTypes, "GMTypeId", "GMTypeId", growMedia.SupplierId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", growMedia.SupplierId);
            return View(growMedia);
        }

        // POST: GrowMedia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GrowMediaId,SupplierId,GMTypeId,Date,Type,Volume,OrderQty,Price,Tax")] GrowMedia growMedia)
        {
            if (id != growMedia.GrowMediaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(growMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrowMediaExists(growMedia.GrowMediaId))
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
            ViewData["SupplierId"] = new SelectList(_context.GrowMediaTypes, "GMTypeId", "GMTypeId", growMedia.SupplierId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", growMedia.SupplierId);
            return View(growMedia);
        }

        // GET: GrowMedia/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growMedia = await _context.GrowMedias
                .Include(g => g.GrowMediaType)
                .Include(g => g.Supplier)
                .FirstOrDefaultAsync(m => m.GrowMediaId == id);
            if (growMedia == null)
            {
                return NotFound();
            }

            return View(growMedia);
        }

        // POST: GrowMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var growMedia = await _context.GrowMedias.FindAsync(id);
            if (growMedia != null)
            {
                _context.GrowMedias.Remove(growMedia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrowMediaExists(Guid id)
        {
            return _context.GrowMedias.Any(e => e.GrowMediaId == id);
        }
    }
}
