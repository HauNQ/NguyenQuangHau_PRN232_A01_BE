using AutoMapper;
using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System.Collections.Generic;

namespace FUNewsManagementSystem.Application.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _repository;
        private readonly IMapper _mapper;

        public NewsArticleService(INewsArticleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<NewsArticleDTO> GetAll()
        {
            var articles = _repository.GetAll();
            return _mapper.Map<IEnumerable<NewsArticleDTO>>(articles);
        }

        public NewsArticleDTO GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity == null ? null : _mapper.Map<NewsArticleDTO>(entity);
        }

        public int Add(NewsArticleDTO newsDTO)
        {
            var entity = _mapper.Map<NewsArticle>(newsDTO);
            entity.CreatedDate = DateTime.Now;
            _repository.Add(entity);
            _repository.Save();
            return entity.Id;
        }

        public bool Update(NewsArticleDTO newsDTO)
        {
            var existing = _repository.GetById(newsDTO.Id);
            if (existing == null) return false;

            _mapper.Map(newsDTO, existing);
            _repository.Update(existing);
            _repository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return false;

            _repository.Delete(id);
            _repository.Save();
            return true;
        }

        public IEnumerable<NewsArticleDTO> Search(string keyword)
        {
            var articles = _repository.Search(keyword);
            return _mapper.Map<IEnumerable<NewsArticleDTO>>(articles);
        }
    }
}
