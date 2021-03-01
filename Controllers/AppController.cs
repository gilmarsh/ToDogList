using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDogList.Areas.Identity.Data;
using ToDogList.Data;
using ToDogList.Models;
using ToDogList.ViewModel;

namespace ToDogList.Controllers
{
    [Authorize]
    public class AppController : Controller
    {
        private UserManager<ToDogListUser> userManager;
        private ApplicationDbContext context;
        private static int completedTasks;

        public AppController(UserManager<ToDogListUser> usrMgr, ApplicationDbContext dbContext)
        {
            userManager = usrMgr;
            context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            List<ToDoItem> userItems = new List<ToDoItem>();
            foreach (ToDoItem item in context.ToDoItems.ToList())
            {
                if (item.UserId.Equals(userManager.GetUserAsync(User).Result.Id))
                {
                    userItems.Add(item);
                }
            }

            List<DogPicture> pictures = new List<DogPicture>();
            using (var httpClient = new HttpClient())
            {
                for (int i = 0; i < completedTasks; i++)
                {
                    using (var response = await httpClient.GetAsync("https://dog.ceo/api/breeds/image/random"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        DogPicture picture = JsonConvert.DeserializeObject<DogPicture>(apiResponse);
                        pictures.Add(picture);
                    }
                }
            }

            ViewBag.pictures = pictures;
            ViewBag.completed = completedTasks;
            completedTasks = 0;

            return View(userItems);
        }

        [HttpPost]
        [Route("/App")]
        public IActionResult CompleteItems(int[] itemIds)
        {
            foreach (int itemId in itemIds)
            {
                ToDoItem item = context.ToDoItems.Find(itemId);
                item.Complete = true;
                completedTasks += 1;
            }
            context.SaveChanges();

            return Redirect("/App");
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
                ToDoItem newItem = new ToDoItem
                {
                    Name = addToDoViewModel.Name,
                    UserId = userManager.GetUserAsync(User).Result.Id
                };
                context.Add(newItem);
                context.SaveChanges();

                return Redirect("/App");
            }
            return View(addToDoViewModel);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            List<ToDoItem> userItems = new List<ToDoItem>();
            foreach (ToDoItem item in context.ToDoItems.ToList())
            {
                if (item.UserId.Equals(userManager.GetUserAsync(User).Result.Id))
                {
                    userItems.Add(item);
                }
            }
            return View(userItems);
        }

        [HttpPost]
        public IActionResult Delete(int[] itemIds)
        {
            foreach (int itemId in itemIds)
            {
                context.Remove(context.ToDoItems.Find(itemId));
            }
            context.SaveChanges();

            return Redirect("/App");
        }
    }
}
