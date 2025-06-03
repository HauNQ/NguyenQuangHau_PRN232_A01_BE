using AutoMapper;
using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System.Collections.Generic;

namespace FUNewsManagementSystem.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TagDTO> GetAll()
        {
            var tags = _repository.GetAll();
            return _mapper.Map<IEnumerable<TagDTO>>(tags);
        }

        public TagDTO? GetById(int id)
        {
            var tag = _repository.GetById(id);
            return tag == null ? null : _mapper.Map<TagDTO>(tag);
        }

        public int Add(TagDTO tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            _repository.Add(tag);
            _repository.Save();
            return tag.Id;
        }

        public bool Update(TagDTO tagDto)
        {
            var existingTag = _repository.GetById(tagDto.Id);
            if (existingTag == null) return false;

            _mapper.Map(tagDto, existingTag);
            _repository.Update(existingTag);
            _repository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var existingTag = _repository.GetById(id);
            if (existingTag == null) return false;

            _repository.Delete(id);
            _repository.Save();
            return true;
        }
    }
}
