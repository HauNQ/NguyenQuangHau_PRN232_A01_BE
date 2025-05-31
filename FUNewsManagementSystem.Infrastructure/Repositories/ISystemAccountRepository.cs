using FUNewsManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Infrastructure.Repositories
{
    public interface ISystemAccountRepository
    {
        Task<List<SystemAccount>> GetAllAsync();
        Task<SystemAccount?> GetByIdAsync(int id);
        Task AddAsync(SystemAccount account);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(SystemAccount account);
        Task<SystemAccount?> LoginAsync(string email, string password);
    }
}
