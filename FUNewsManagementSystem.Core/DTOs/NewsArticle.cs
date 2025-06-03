using FUNewsManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Core.DTOs
{
    // record class NewsArticle(string Title, string Content, int Status, int CategoryId, int SystemAccountId);

        public class NewsArticleDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime CreatedDate { get; set; }
            public int Status { get; set; }
            public int CategoryId { get; set; }
            public int SystemAccountId { get; set; }
            public List<TagDTO> Tags { get; set; } // Assuming you want tags here
        }


}

