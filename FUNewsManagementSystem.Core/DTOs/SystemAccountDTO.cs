using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Core.DTOs
{
    public class SystemAccountDTO
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }
    }
}
