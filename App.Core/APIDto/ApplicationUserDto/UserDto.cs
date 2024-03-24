using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.APIDto.ApplicationUserDto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Gender { get; set; }              
    }
}
