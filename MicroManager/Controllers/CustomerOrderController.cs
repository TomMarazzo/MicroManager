using MicroManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroManager.Controllers
{
    public class CustomerOrderController : Controller
    {
        public IActionResult StoreIndex()
        {
            //Use Fake Product Category data to display
            //1. Create and object to hold a list of ProductCategories
            var productCategories = new List<ProductCategory>();
            //for(var i = 1; i <= 10; i++)
            //{
            //    productCategories.Add(new ProductCategory { ProductCategoryId = i, ProductName = "Product Category " + i.ToString() });
            //}
            return View(productCategories);
        }

        public IActionResult Browse(string category)
        {
            ViewBag.category = category;
            return View();
        }

        //CustomerOrder/Store
        public IActionResult AddProductCategory() 
        {
            //Load a form to capture an Object from a user
            return View();
        }
    }
}
