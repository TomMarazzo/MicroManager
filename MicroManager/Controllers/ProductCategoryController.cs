﻿using MicroManager.Data;
using MicroManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroManager.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ProductCategory> ObjProductCategorList = _context.ProductCategories;
            return View(ObjProductCategorList);

        //https://www.youtube.com/watch?v=2gvpldoygak This is the Tutorial I used to make this section of the App
        }

        //GET
        public IActionResult Create()
        {
            
            return View();

            //https://www.youtube.com/watch?v=2gvpldoygak This is the Tutorial I used to make this section of the App
        }
    }
}
