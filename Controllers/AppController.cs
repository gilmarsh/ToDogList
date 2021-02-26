using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDogList.Areas.Identity.Data;

namespace ToDogList.Controllers
{
    [Authorize]
    public class AppController : Controller
    {
        private UserManager<ToDogListUser> userManager;

        public AppController(UserManager<ToDogListUser> usrMgr)
        {
            userManager = usrMgr;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
