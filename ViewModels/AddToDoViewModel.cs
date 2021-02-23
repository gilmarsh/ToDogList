using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDogList.ViewModels
{
    public class AddToDoViewModel
    {
        [Required(ErrorMessage = "Please enter a task.")]
        public string Name { get; set; }
    }
}
