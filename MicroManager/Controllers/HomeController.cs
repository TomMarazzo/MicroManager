using MicroManager.Data;
using MicroManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace MicroManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        //This is to ID who is logged into the system
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;


        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            IdentityUser identityUser = new()
            {
                Email = "farmer@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                UserName = "farmer@gmail.com",
                Id = "102C6813-06B9-4ED3-B9E2-1ED91E5B4D38",
            };
            var user = await _userManager.FindByIdAsync(identityUser.Id);
            if (user == null)
            {
               var result = await _userManager.CreateAsync(identityUser);

                if(result.Succeeded)
                {
                    user = await _userManager.FindByIdAsync(identityUser.Id);
                    await _userManager.AddPasswordAsync(user, "password");
                }
                
            }
            else
            {
                if (user.PasswordHash == null)
                {
                    var passresult = await _userManager.AddPasswordAsync(user, "Password123!");
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
