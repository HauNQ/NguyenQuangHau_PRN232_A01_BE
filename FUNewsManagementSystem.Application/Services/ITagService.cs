using FUNewsManagementSystem.Core.DTOs;
using System.Collections.Generic;

namespace FUNewsManagementSystem.Application.Services
{
    public interface ITagService
    {
        IEnumerable<TagDTO> GetAll();
        TagDTO? GetById(int id);
        int Add(TagDTO tagDto);
        bool Update(TagDTO tagDto);
        bool Delete(int id);
    }
}
