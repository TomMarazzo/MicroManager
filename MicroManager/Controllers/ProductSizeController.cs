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
    public class ProductSizeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductSizeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductSize
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductSize.ToListAsync());
        }

        // GET: ProductSize/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await _context.ProductSize
                .FirstOrDefaultAsync(m => m.ProductSizeId == id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // GET: ProductSize/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductSize/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSizeId,Size")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                productSize.ProductSizeId = Guid.NewGuid();
                _context.Add(productSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSize);
        }

        // GET: ProductSize/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await _context.ProductSize.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }
            return View(productSize);
        }

        // POST: ProductSize/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductSizeId,Size")] ProductSize productSize)
        {
            if (id != productSize.ProductSizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSizeExists(productSize.ProductSizeId))
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
            return View(productSize);
        }

        // GET: ProductSize/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await _context.ProductSize
                .FirstOrDefaultAsync(m => m.ProductSizeId == id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // POST: ProductSize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productSize = await _context.ProductSize.FindAsync(id);
            if (productSize != null)
            {
                _context.ProductSize.Remove(productSize);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSizeExists(Guid id)
        {
            return _context.ProductSize.Any(e => e.ProductSizeId == id);
        }
    }
}
