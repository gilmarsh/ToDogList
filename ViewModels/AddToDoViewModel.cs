using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ToDogList.Areas.Identity.Data;
using System.Security.Claims;

namespace ToDogList.ViewModels
{
    public class AddToDoViewModel
    {
        [Required(ErrorMessage = "Please enter a task.")]
        public string Name { get; set; }

    }
}
