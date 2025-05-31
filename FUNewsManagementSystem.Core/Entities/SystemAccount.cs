using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Core.Entities
{
    public class SystemAccount
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Role { get; set; } // 1: Staff, 2: Lecturer

        public virtual ICollection<NewsArticle> NewsArticles { get; set; }
    }
}
