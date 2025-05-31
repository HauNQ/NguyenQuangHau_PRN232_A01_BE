using FUNewsManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public interface INewsArticleService
    {
        IEnumerable<NewsArticle> GetAll();
        NewsArticle GetById(int id);
        void Add(NewsArticle news);
        void Update(NewsArticle news);
        void Delete(int id);
        IEnumerable<NewsArticle> Search(string keyword);
    }

}
