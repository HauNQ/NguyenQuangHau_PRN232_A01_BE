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
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.Include(t => t.NewsArticle).ToList();
        }

        public Tag? GetById(int id)
        {
            return _context.Tags.Include(t => t.NewsArticle).FirstOrDefault(t => t.Id == id);
        }

        public void Add(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tag = GetById(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }
    }
}
