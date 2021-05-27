using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vue_Mvc.Models;

namespace Vue_Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DataContext context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       public IActionResult Login(User user) 
        {
            var userInfo = context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if(userInfo == null)
            {
                return View();
            }else if (userInfo.Email == user.Email && userInfo.Password == user.Password)
            {
                
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
