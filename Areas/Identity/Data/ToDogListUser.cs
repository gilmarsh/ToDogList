using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ToDogList.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ToDogListUser class
    public class ToDogListUser : IdentityUser
    {
        [PersonalData]
        [Required]
        public string Name { get; set; }
    }
}
