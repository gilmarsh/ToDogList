using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDogList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Complete { get; set; }
        public string UserId { get; set; }

        public ToDoItem()
        {
            Complete = false;
        }

        public ToDoItem(string name) : this()
        {
            Name = name;
        }
    }
}
