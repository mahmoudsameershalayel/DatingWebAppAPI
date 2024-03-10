using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.APIViewModel
{
    public class ApplicationUserViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public string BirthDate { get; set; }  = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;
        public string? ImageName { get; set; }
    }
}