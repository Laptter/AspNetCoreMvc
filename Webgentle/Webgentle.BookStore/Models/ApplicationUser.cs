﻿using Microsoft.AspNetCore.Identity;

namespace Webgentle.BookStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
