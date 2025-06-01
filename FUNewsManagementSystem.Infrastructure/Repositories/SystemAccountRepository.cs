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

        public IEnumerable<SystemAccount> GetAll()
        {
            return _context.SystemAccounts.Include(a => a.NewsArticles).ToList();
        }

        public SystemAccount? GetById(int id)
        {
            return _context.SystemAccounts.Include(a => a.NewsArticles).FirstOrDefault(a => a.Id == id);
        }

        public void Add(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            _context.SaveChanges();
        }

        public void Update(SystemAccount account)
        {
            _context.SystemAccounts.Update(account);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var account = GetById(id);
            if (account != null)
            {
                _context.SystemAccounts.Remove(account);
                _context.SaveChanges();
            }
        }
    }

}
