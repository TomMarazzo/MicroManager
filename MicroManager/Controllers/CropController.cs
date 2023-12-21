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
    public class CropController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CropController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Crop
        public async Task<IActionResult> CropIndex()
        {
            return View(await _context.Crops.ToListAsync());
        }

        // GET: Crop/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops
                .FirstOrDefaultAsync(m => m.CropId == id);
            if (crop == null)
            {
                return NotFound();
            }

            return View(crop);
        }

        // GET: Crop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CropId,Name,SeedDensity,SoakHours,GerminationDays,StackDays,BlackOutDays,WeightedDays,TotalGrowthDays,ExpectedYield")] Crop crop)
        {
            if (ModelState.IsValid)
            {
                crop.CropId = Guid.NewGuid();
                _context.Add(crop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CropIndex));
            }
            return View(crop);
        }

        // GET: Crop/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }
            return View(crop);
        }

        // POST: Crop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CropId,Name,SeedDensity,SoakHours,GerminationDays,StackDays,BlackOutDays,WeightedDays,TotalGrowthDays,ExpectedYield")] Crop crop)
        {
            if (id != crop.CropId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CropExists(crop.CropId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CropIndex));
            }
            return View(crop);
        }

        // GET: Crop/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = await _context.Crops
                .FirstOrDefaultAsync(m => m.CropId == id);
            if (crop == null)
            {
                return NotFound();
            }

            return View(crop);
        }

        // POST: Crop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var crop = await _context.Crops.FindAsync(id);
            if (crop != null)
            {
                _context.Crops.Remove(crop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CropIndex));
        }

        private bool CropExists(Guid id)
        {
            return _context.Crops.Any(e => e.CropId == id);
        }
    }
}
