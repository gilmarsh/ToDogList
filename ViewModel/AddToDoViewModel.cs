using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDogList.ViewModel
{
    public class AddToDoViewModel
    {
        [Required(ErrorMessage = "Task name is required.")]
        public string Name { get; set; }
    }
}
