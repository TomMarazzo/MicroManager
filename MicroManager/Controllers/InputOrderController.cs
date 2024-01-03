using MicroManager.Data;
using Microsoft.AspNetCore.Mvc;
using MicroManager.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace MicroManager.Controllers
{
    public class InputOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InputOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Get a list of ProductCategories (ProductCategoryController) to display 
            var productCategories = _context.ProductCategory.OrderBy(c => c.ProductName).ToList();       
            
            return View(productCategories);
        }

        //InpuOrder/Browse
        public IActionResult Browse(Guid id)
        {
            //Query Products for the selected ProductCategory
            var products = _context.Products.Where(p => p.ProductCategory_Id == id).OrderBy(p => p.Seed_Id).ToList();
            //Get the name of the selected ProductCategory then Find() and filter by key fields
            ViewBag.productCategories = _context.ProductCategory.Find(id).ProductName.ToString();
            return View(products);
        }
    }
}
