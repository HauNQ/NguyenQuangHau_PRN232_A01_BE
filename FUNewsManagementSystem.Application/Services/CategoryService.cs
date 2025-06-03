using AutoMapper;
using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System.Collections.Generic;

namespace FUNewsManagementSystem.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public CategoryDTO GetById(int id)
        {
            var entity = _repo.GetById(id);
            if (entity == null) return null;

            var dto = _mapper.Map<CategoryDTO>(entity);
            return dto;
        }

        public int Add(CategoryDTO catDTO)
        {
            // Map DTO to Entity directly
            var category = _mapper.Map<Category>(catDTO);

            // If you want to enforce default status = 1, override here:
            category.Status = 1;

            _repo.Add(category);
            _repo.Save();
            return category.Id;
        }

        public bool Update(CategoryDTO catDTO)
        {
            var existingCategory = _repo.GetById(catDTO.Id);
            if (existingCategory == null) return false;

            // Map updated fields from DTO into existing entity
            _mapper.Map(catDTO, existingCategory);

            _repo.Update(existingCategory);
            _repo.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var category = _repo.GetById(id);
            if (category == null || _repo.IsUsedByNews(id)) return false;

            category.Status = 0;
            _repo.Update(category);
            _repo.Save();

            return true;
        }

        IEnumerable<CategoryDTO> ICategoryService.GetAll()
        {
            var entities = _repo.GetAll();
            var dtos = _mapper.Map<IEnumerable<CategoryDTO>>(entities);
            return dtos;
        }
    }
}
