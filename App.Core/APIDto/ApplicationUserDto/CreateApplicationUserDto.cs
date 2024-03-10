using App.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.APIDto.ApplicationUserDto
{
    public class CreateApplicationUserDto
    {
        [Required(ErrorMessage = "*Username is Required")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Full Name is Required")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Email is Required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Phone is Required")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Birth date is Required")]
        public string BirthDate { get; set; } = "";
        [Required(ErrorMessage = "*Password is Required")]
        public string Password { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public int? Gender { get; set; }
        public string? ImageName { get; set; }
    }
}
