using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Core.DTOs
{
    // public record TagDTO(string Name, int? NewsArticleId);
    public class TagDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? NewsArticleId { get; set; }
    }

}
