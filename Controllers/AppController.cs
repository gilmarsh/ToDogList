using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDogList.Areas.Identity.Data;
using ToDogList.Data;
using ToDogList.Models;
using ToDogList.ViewModels;

namespace ToDogList.Controllers
{
    public class AppController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<ToDogListUser> userManager;

        public AppController(ApplicationDbContext dbContext, UserManager<ToDogListUser> manager)
        {
            userManager = manager;
            context = dbContext;
        }

        // GET: AppController
        [HttpGet]
        public ActionResult Index()
        {
            List<ToDoItem> toDos = context.ToDoItems.ToList();
            
            return View(toDos);
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            AddToDoViewModel addToDoViewModel = new AddToDoViewModel();
            return View(addToDoViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddToDoViewModel addToDoViewModel)
        {
            if (ModelState.IsValid)
            {
                ClaimsPrincipal currentUser = User;
                ToDogListUser user = userManager.GetUserAsync(User).Result;
                ToDoItem newToDo = new ToDoItem
                {
                    Name = addToDoViewModel.Name,
                    UserId = user.Id
                
                };
                context.ToDoItems.Add(newToDo);
                context.SaveChanges();

                return Redirect("/App");
            }
            return View(addToDoViewModel);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            //make a viewmodel if time
            //ViewBag.toDos = context.ToDoItems.ToList();
            List<ToDoItem> userItems = new List<ToDoItem>();
            foreach (ToDoItem toDo in context.ToDoItems.ToList())
            {
                ClaimsPrincipal currentUser = User;
                ToDogListUser user = userManager.GetUserAsync(User).Result;
                if (toDo.UserId == user.Id)
                {
                    userItems.Add(toDo);
                }    
            }
            ViewBag.toDos = userItems;
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] toDoIds)
        {
            foreach (int toDoId in toDoIds)
            {
                ToDoItem theToDo = context.ToDoItems.Find(toDoId);
                context.ToDoItems.Remove(theToDo);
            }

            context.SaveChanges();

            return Redirect("/App");
        }
    }
}
