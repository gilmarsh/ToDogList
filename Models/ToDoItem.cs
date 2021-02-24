using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDogList.Areas.Identity.Data;

namespace ToDogList.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool Complete { get; set; }
        public ToDogListUser User { get; set; }
        public string UserId { get; set; }



        public ToDoItem()
        {
            Complete = false;
        }

        public ToDoItem(string name): this()
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool IsCompleted()
        {
            return Complete;
        }

        public override bool Equals(object obj)
        {
            return obj is ToDoItem @todoitem &&
                Id == todoitem.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
