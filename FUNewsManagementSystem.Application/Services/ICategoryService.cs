using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO GetById(int id);
        int Add(CategoryDTO catDTO);
        bool Update(CategoryDTO catDTO);
        bool Delete(int id);
    }

}
