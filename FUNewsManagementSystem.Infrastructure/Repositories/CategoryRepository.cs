using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) => _context = context;

        public IEnumerable<Category> GetAll() => _context.Categories.ToList();
        public Category GetById(int id) => _context.Categories.Find(id);
        public void Add(Category category) => _context.Categories.Add(category);
        public void Update(Category category) => _context.Categories.Update(category);
        public void Delete(Category category) => _context.Categories.Remove(category);
        public bool IsUsedByNews(int categoryId) => _context.NewsArticles.Any(n => n.CategoryId == categoryId);
        public void Save() => _context.SaveChanges();
    }

}
