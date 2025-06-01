using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepository _repository;

        public SystemAccountService(ISystemAccountRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SystemAccount> GetAll() => _repository.GetAll();

        public SystemAccount? GetById(int id) => _repository.GetById(id);

        public void Add(SystemAccount account) => _repository.Add(account);

        public void Update(SystemAccount account) => _repository.Update(account);

        public void Delete(int id) => _repository.Delete(id);

        public Task<SystemAccount?> LoginAsync(string email, string password)
        {
           return _repository.LoginAsync(email, password);
        }
    }
}
