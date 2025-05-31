using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Core.Entities
{
    public class NewsArticle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int Status { get; set; } // 1: Active, 0: Inactive

        // FK: Category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // FK: SystemAccount
        [ForeignKey("SystemAccount")]
        public int SystemAccountId { get; set; }
        public virtual SystemAccount SystemAccount { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
