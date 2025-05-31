using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo) => _repo = repo;

        public IEnumerable<Category> GetAll() => _repo.GetAll();
        public Category GetById(int id) => _repo.GetById(id);

        public bool Add(Category category)
        {
            _repo.Add(category);
            _repo.Save();
            return true;
        }

        public bool Update(Category category)
        {
            _repo.Update(category);
            _repo.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var category = _repo.GetById(id);
            if (category == null || _repo.IsUsedByNews(id)) return false;

            _repo.Delete(category);
            _repo.Save();
            return true;
        }
    }

}
