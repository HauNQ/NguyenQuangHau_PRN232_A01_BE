using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Core.DTOs
{
    /*public record LoginDto
    ( string Email,  string Password);*/

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDto() { }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

}
