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
            //Get a list of Categories to display 
            var productCategories = _context.ProductCategory.OrderBy(c => c.ProductName).ToList();       
            
            return View(productCategories);
        }

        //InpuOrder/Browse
        public IActionResult Browse(Guid id)
        {
            //Quiry Products for the selected category
            var products = _context.Products.Where(p => p.ProductId == id).OrderBy(p => p.Seed_Id).ToList();
            return View();
        }
    }
}
