using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _repository;

        public NewsArticleService(INewsArticleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<NewsArticle> GetAll() => _repository.GetAll();

        public NewsArticle GetById(int id) => _repository.GetById(id);

        public void Add(NewsArticle news) => _repository.Add(news);

        public void Update(NewsArticle news) => _repository.Update(news);

        public void Delete(int id) => _repository.Delete(id);

        public IEnumerable<NewsArticle> Search(string keyword) => _repository.Search(keyword);
    }

}
