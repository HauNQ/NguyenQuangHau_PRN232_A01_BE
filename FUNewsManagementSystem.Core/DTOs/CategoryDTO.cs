using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Core.DTOs
{
    //    public record CategoryDTO(int Id,[Required] string Name, int Status);

    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Status { get; set; }

        public CategoryDTO() { }

        public CategoryDTO(int id, string name, int status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }


}
