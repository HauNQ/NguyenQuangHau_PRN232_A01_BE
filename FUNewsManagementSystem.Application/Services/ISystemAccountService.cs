using FUNewsManagementSystem.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public interface ISystemAccountService
    {
        IEnumerable<SystemAccountDTO> GetAll();
        SystemAccountDTO? GetById(int id);
        int Add(SystemAccountDTO accountDTO);
        bool Update(SystemAccountDTO accountDTO);
        bool Delete(int id);

        Task<SystemAccountDTO?> LoginAsync(string email, string password);
    }
}
