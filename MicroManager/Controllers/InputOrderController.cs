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
using Castle.Components.DictionaryAdapter.Xml;


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

        public IActionResult AddToCart(Guid ProductId, int Quantity)
        {
            // Query the DB for the Product Price
            var price = _context.Products.Find(ProductId)?.Price;

            if (price == null)
            {
                // Handle the case when the product is not found
                // You might want to return an error or redirect to an error page
                return RedirectToAction("Error");
            }

            // Get the current Date & time using the built-in .Net function
            var currentDateTime = DateTime.Now;

            // EmployeeId variable
            var employeeId = GetEmployeeId();

            // Create and Save a new Cart Object
            var cart = new Cart
            {
                Product_Id = ProductId,
                Quantity = Quantity,
                Price = (double)price,
                DateCreated = currentDateTime,
                Employee_Id = employeeId
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();

            // Redirect to Cart View
            return RedirectToAction("Cart");
        }

        private Guid GetEmployeeId()
        {
            // Check the Session for Existing EmployeeId
            if (HttpContext.Session.GetString("EmployeeId") == null)
            {
                // If we don't already have an EmployeeId in the session, check if the Employee is logged in
                var employeeId = "";

                // If the customer is logged in, use their email as the EmployeeId
                if (User.Identity.IsAuthenticated)
                {
                    employeeId = User.Identity.Name; // Use email address as the identifier name
                }
                // If the employee is anonymous, use Guid to create a new identifier
                else
                {
                    Guid employeeGuid = Guid.NewGuid();
                    employeeId = employeeGuid.ToString();
                }

                // Now, store the EmployeeId in a Session variable
                HttpContext.Session.SetString("EmployeeId", employeeId);
            }

            // Return the Session Variable
            return Guid.Parse(HttpContext.Session.GetString("EmployeeId"));
        }

        // InputOrder/Cart
        public IActionResult Cart()
        {
            // Fetch Current cart for Display
            var employeeId = GetEmployeeId(); // Get the Guid directly

            // Query the DB for the Employee's cart items
            var cartItems = _context.Carts.Where(c => c.Employee_Id == employeeId).ToList();

            // Pass Data to the View for display
            return View(cartItems);
        }


    }
}
