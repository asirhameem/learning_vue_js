using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
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
            }else if (userInfo.Email == user.Email && userInfo.Password == user.Password && userInfo.Type == "Regular")
            {

                return RedirectToAction("Index");
            }
            else if(userInfo.Email == user.Email && userInfo.Password == user.Password && userInfo.Type == "Admin")
            {
                return View("AdminDashboard");
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult CreateTask([FromBody] Models.Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
            string url = Url.Link("TaskById", new { id = task.Id });
            return Created(url, task);
        } 

        [HttpGet]
        [Route("Task/{id}", Name ="TaskById")]
        public IActionResult TaskById(int id)
        {
            var task = context.Tasks.Where(x => x.Id == id);

            return Ok(task);
        }

        [HttpGet]
        [Route("Pendings")]
        public IActionResult AllPendingTasks()
        {
            var tasks = context.Tasks.Where(x => x.TaskStatus == "Pending").ToList();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("AllTasks", Name ="AllTasks")]
        public IActionResult AllTasks()
        {
            var tasks = context.Tasks.ToList();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("Update")]
        public IActionResult UpdateTask(int id, [FromBody] Models.Task task)
        {
            context.Entry(task).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }





        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
