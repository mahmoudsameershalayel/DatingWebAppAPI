using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.APIDto.ApplicationUserDto
{
    public class UpdateApplicationUserDto
    {
        public string Id { get; set; } = "";
        [Required(ErrorMessage = "*Full name is Required")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Email is Required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Phone is Required")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "*Birth date is Required")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "*Password is Required")]
        public string Password { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
