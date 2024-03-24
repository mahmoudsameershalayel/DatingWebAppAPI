using App.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DbEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public UserType UserType { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime Created_At { get; set; } = DateTime.Now;
        public string? Created_By { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now;
        public string? Updated_by { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
        public string LookingFor { get; set; } = string.Empty;
        public string Introduction { get; set; }=string.Empty;
        public string? ImageName { get; set; }
        public int getAge()
        {
            return DateTime.Today.Year - this.BirthDate.Year;
        }
    }
}
