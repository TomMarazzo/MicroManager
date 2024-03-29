﻿using System;
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
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductCategory).Include(p => p.ProductSize).Include(p => p.Seeds).OrderBy(p => p.ProductCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductSize)
                .Include(p => p.Seeds)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["ProductCategory_Id"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductName");
            ViewData["Product_ProductSize_Id"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size");
            ViewData["Seed_Id"] = new SelectList(_context.Seeds, "SeedId", "Type");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var seed = await _context.Seeds.FirstAsync(a => a.SeedId == product.Seed_Id);
            product.Seeds = seed;
            if (ModelState.IsValid)
            {
                product.ProductId = Guid.NewGuid();
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategory_Id"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductName", product.ProductCategory_Id);
            ViewData["Product_ProductSize_Id"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size", product.Product_ProductSize_Id);
            ViewData["Seed_Id"] = new SelectList(_context.Seeds, "SeedId", "Type", product.Seed_Id);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategory_Id"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductName", product.ProductCategory_Id);
            ViewData["Product_ProductSize_Id"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size", product.Product_ProductSize_Id);
            ViewData["Seed_Id"] = new SelectList(_context.Seeds, "SeedId", "Type", product.Seed_Id);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["ProductCategory_Id"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductName", product.ProductCategory_Id);
            ViewData["Product_ProductSize_Id"] = new SelectList(_context.ProductSizes, "ProductSizeId", "Size", product.Product_ProductSize_Id);
            ViewData["Seed_Id"] = new SelectList(_context.Seeds, "SeedId", "Type", product.Seed_Id);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductSize)
                .Include(p => p.Seeds)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
