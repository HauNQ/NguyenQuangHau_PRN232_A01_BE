using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Infrastructure.Repositories
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly AppDbContext _context;
        public SystemAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var account = await _context.SystemAccounts
                .Include(a => a.NewsArticles)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (account == null || account.NewsArticles.Any())
                return false;

            _context.SystemAccounts.Remove(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SystemAccount>> GetAllAsync() =>
            await _context.SystemAccounts.ToListAsync();

        public async Task<SystemAccount?> GetByIdAsync(int id) =>
            await _context.SystemAccounts.FindAsync(id);

        public async Task<bool> UpdateAsync(SystemAccount account)
        {
            _context.SystemAccounts.Update(account);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<SystemAccount?> LoginAsync(string email, string password) =>
            await _context.SystemAccounts
                .FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
    }

}
