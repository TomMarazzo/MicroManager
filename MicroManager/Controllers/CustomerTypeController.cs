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
    public class CustomerTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerType
        public async Task<IActionResult> CusTypeIndex()
        {
            return View(await _context.CustomerTypes.ToListAsync());
        }

        // GET: CustomerType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerTypes
                .FirstOrDefaultAsync(m => m.CustomerTypeId == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // GET: CustomerType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerTypeId,Type")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                customerType.CustomerTypeId = Guid.NewGuid();
                _context.Add(customerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CusTypeIndex));
            }
            return View(customerType);
        }

        // GET: CustomerType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerTypes.FindAsync(id);
            if (customerType == null)
            {
                return NotFound();
            }
            return View(customerType);
        }

        // POST: CustomerType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustomerTypeId,Type")] CustomerType customerType)
        {
            if (id != customerType.CustomerTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTypeExists(customerType.CustomerTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CusTypeIndex));
            }
            return View(customerType);
        }

        // GET: CustomerType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerTypes
                .FirstOrDefaultAsync(m => m.CustomerTypeId == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // POST: CustomerType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerType = await _context.CustomerTypes.FindAsync(id);
            if (customerType != null)
            {
                _context.CustomerTypes.Remove(customerType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CusTypeIndex));
        }

        private bool CustomerTypeExists(Guid id)
        {
            return _context.CustomerTypes.Any(e => e.CustomerTypeId == id);
        }
    }
}
