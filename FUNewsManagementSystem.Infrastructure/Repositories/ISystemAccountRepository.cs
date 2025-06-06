﻿using FUNewsManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Infrastructure.Repositories
{
    public interface ISystemAccountRepository
    {
        IEnumerable<SystemAccount> GetAll();
        SystemAccount? GetById(int id);
        void Add(SystemAccount account);
        void Update(SystemAccount account);
        void Delete(int id);
        Task<SystemAccount?> LoginAsync(string email, string password);
    }
}
