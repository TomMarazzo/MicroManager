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
    public class GrowMediaTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrowMediaTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GrowMediaType
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrowMediaTypes.ToListAsync());
        }

        // GET: GrowMediaType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growMediaType = await _context.GrowMediaTypes
                .FirstOrDefaultAsync(m => m.GMTypeId == id);
            if (growMediaType == null)
            {
                return NotFound();
            }

            return View(growMediaType);
        }

        // GET: GrowMediaType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrowMediaType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GMTypeId,Type")] GrowMediaType growMediaType)
        {
            if (ModelState.IsValid)
            {
                growMediaType.GMTypeId = Guid.NewGuid();
                _context.Add(growMediaType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(growMediaType);
        }

        // GET: GrowMediaType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growMediaType = await _context.GrowMediaTypes.FindAsync(id);
            if (growMediaType == null)
            {
                return NotFound();
            }
            return View(growMediaType);
        }

        // POST: GrowMediaType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GMTypeId,Type")] GrowMediaType growMediaType)
        {
            if (id != growMediaType.GMTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(growMediaType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrowMediaTypeExists(growMediaType.GMTypeId))
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
            return View(growMediaType);
        }

        // GET: GrowMediaType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growMediaType = await _context.GrowMediaTypes
                .FirstOrDefaultAsync(m => m.GMTypeId == id);
            if (growMediaType == null)
            {
                return NotFound();
            }

            return View(growMediaType);
        }

        // POST: GrowMediaType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var growMediaType = await _context.GrowMediaTypes.FindAsync(id);
            if (growMediaType != null)
            {
                _context.GrowMediaTypes.Remove(growMediaType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrowMediaTypeExists(Guid id)
        {
            return _context.GrowMediaTypes.Any(e => e.GMTypeId == id);
        }
    }
}
