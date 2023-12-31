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
    public class CustomerOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerOrder
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.CustomerOrders.Include(c => c.Customer).Include(c => c.Product).ToListAsync();
            return View(applicationDbContext);
        }

        // GET: CustomerOrder/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CustomerOrderId == id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        // GET: CustomerOrder/Create
        public IActionResult Create()
        {
            ViewData["Customer_Id"] = new SelectList(_context.Customers, "CustomerId", "CompanyName");
            ViewData["Product_Id"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: CustomerOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                customerOrder.CustomerOrderId = Guid.NewGuid();
                _context.Add(customerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_Id"] = new SelectList(_context.Customers, "CustomerId", "CompanyName", customerOrder.Customer_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "ProductId", "ProductSize");
            return View(customerOrder);
        }

        // GET: CustomerOrder/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders.FindAsync(id);
            if (customerOrder == null)
            {
                return NotFound();
            }
            ViewData["Customer_Id"] = new SelectList(_context.Customers, "CustomerId", "CompanyName", customerOrder.Customer_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "ProductId", "ProductSize", customerOrder.Product_Id);
            return View(customerOrder);
        }

        // POST: CustomerOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  CustomerOrder customerOrder)
        {
            if (id != customerOrder.CustomerOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerOrderExists(customerOrder.CustomerOrderId))
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
            ViewData["Customer_Id"] = new SelectList(_context.Customers, "CustomerId", "CompanyName", customerOrder.Customer_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "ProductId", "ProductId", customerOrder.Product_Id);
            return View(customerOrder);
        }

        // GET: CustomerOrder/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CustomerOrderId == id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        // POST: CustomerOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerOrder = await _context.CustomerOrders.FindAsync(id);
            if (customerOrder != null)
            {
                _context.CustomerOrders.Remove(customerOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerOrderExists(Guid id)
        {
            return _context.CustomerOrders.Any(e => e.CustomerOrderId == id);
        }
    }
}
