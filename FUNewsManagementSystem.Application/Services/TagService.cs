using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Tag> GetAll() => _repository.GetAll();

        public Tag? GetById(int id) => _repository.GetById(id);

        public void Add(Tag tag) => _repository.Add(tag);

        public void Update(Tag tag) => _repository.Update(tag);

        public void Delete(int id) => _repository.Delete(id);
    }
}
