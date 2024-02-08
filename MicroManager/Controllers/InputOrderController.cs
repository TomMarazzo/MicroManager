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
using Microsoft.AspNetCore.Identity;


namespace MicroManager.Controllers
{
    public class InputOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        //This is to ID who is logged into the system
        private readonly UserManager<IdentityUser> _userManager;

        public InputOrderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid ProductId, int Quantity, Guid CustomerId)
        {
            //Getting the UserId to see whos logged in
            var user = await _userManager.GetUserAsync(User);
            var customer = await _context.Customers.FirstAsync();
            if(CustomerId == Guid.Empty)
            {
                CustomerId = customer.CustomerId;
            }
           string employeeId = string.Empty;
            if (user != null) 
            {
                employeeId = user.Id;
            }
            

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
            //var employeeId = GetEmployeeId();

            // Create and Save a new Cart Object
            var cart = new Cart
            {
                Product_Id = ProductId,
                Quantity = Quantity,
                Tax = (float)1.13,
                Price = (float)price,
                DateCreated = currentDateTime,
                Employee_Id = employeeId,
                Customer_Id = CustomerId
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();

            // Redirect to Cart View
            return RedirectToAction("Cart");
        }

        

        // InputOrder/Cart
        public async Task<IActionResult> Cart(Guid CustomerId)
        {
            var customer = await _context.Customers.FirstAsync();
            if(CustomerId == Guid.Empty)
            {
                CustomerId = customer.CustomerId;
            }
            // Query the DB for the Employee's cart items
            var cartItems = _context.Carts.Where(c => c.Customer_Id == CustomerId).ToList();

            // Pass Data to the View for display
            return View(cartItems);
        }


    }
}
