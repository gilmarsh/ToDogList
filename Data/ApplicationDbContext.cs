using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDogList.Areas.Identity.Data;
using ToDogList.Models;

namespace ToDogList.Data
{
    public class ApplicationDbContext : IdentityDbContext<ToDogListUser>
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
