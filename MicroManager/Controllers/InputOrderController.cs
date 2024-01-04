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

        public IActionResult Cart(Guid ProductId, int Quantity, Guid CustomerId)
        {
            //Query the DB for the Product Price
            var price = _context.Products.Find(ProductId).Price;

            //Query the DB for the Customer
            //var customer = _context.Customers.Find(CustomerId).CompanyName; 

            // Get the current Date & time using the built in .Net function
            var currentDateTime = DateTime.Now;

            //CustomerId variable
           // var CustomerId = GetCustomerId();

            //Create and Save a new Cart Object
            var cart = new Cart
            {
                Product_Id = ProductId,
                Quantity = Quantity,
                Price = (double)price,
                DateCreated = currentDateTime,
                Customer_Id = CustomerId
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();
            //Redircet to Cart View
            return RedirectToAction("Cart");
        }

        //private string GetCustomerId()
        //{
        //    //Check the Session for Existing CustomerID
        //    if (HttpContext.Session.GetString("CustomerId") == null)
        //    {
        //        //if we don't already have a CustomerId in the session, check if Customer is logged in
        //        var CustomerId = "";

        //        // if customer is logged in, use their email as the CustomerId
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            CustomerId = User.Identity.Name; //use email address as the identifyer name
        //        }
        //        // if the customer is anonymous, use Guid to create a new identifier
        //        else
        //        {
        //            CustomerId = Guid.NewGuid().ToString();
        //        }
        //        //Now, storer the CustomerId in a Session variable
        //        HttpContext.Session.SetString("CustomerId", Customer_Id);
        //    }
        //    //return the Session Variable
        //    return HttpContext.Session.GetString("CustomerId");
        //}

        //InpuOrder/Cart
        //public IActionResult Cart()
        //{
        //    //Fetch Current cart for Display
        //    var CustomerId = "";
        //    //In case User cpmes to Care Page before Adding Anything, Identify them first
        //    if (HttpContext.Session.GetString("CustomerId") == null)
        //    {
        //        CustomerId = GetCustomerId();
        //    }
        //    else
        //    {
        //        CustomerId = HttpContext.Session.GetString("CustomerId");
        //    }
        //    //Query the DB for the Customer
        //    var cartItems = _context.Carts;
        //    //Pass Data to the View for display
        //    return View(cartItems);
        //}
    }
}
