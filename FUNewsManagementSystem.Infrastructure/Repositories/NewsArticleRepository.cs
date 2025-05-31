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
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly AppDbContext _context;

        public NewsArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<NewsArticle> GetAll()
        {
            return _context.NewsArticles.Include(n => n.Category).Include(n => n.Tags).ToList();
        }

        public NewsArticle GetById(int id)
        {
            return _context.NewsArticles.Include(n => n.Category).Include(n => n.Tags).FirstOrDefault(n => n.Id == id);
        }

        public void Add(NewsArticle news)
        {
            _context.NewsArticles.Add(news);
            _context.SaveChanges();
        }

        public void Update(NewsArticle news)
        {
            _context.NewsArticles.Update(news);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var news = GetById(id);
            if (news != null)
            {
                _context.NewsArticles.Remove(news);
                _context.SaveChanges();
            }
        }

        public IEnumerable<NewsArticle> Search(string keyword)
        {
            return _context.NewsArticles
                .Where(n => n.Title.Contains(keyword) || n.Content.Contains(keyword))
                .ToList();
        }
    }

}
