using AutoMapper;
using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepository _repository;
        private readonly IMapper _mapper;

        public SystemAccountService(ISystemAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<SystemAccountDTO> GetAll()
        {
            var entities = _repository.GetAll();
            return _mapper.Map<IEnumerable<SystemAccountDTO>>(entities);
        }

        public SystemAccountDTO? GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity == null ? null : _mapper.Map<SystemAccountDTO>(entity);
        }

        public int Add(SystemAccountDTO dto)
        {
            var entity = _mapper.Map<SystemAccount>(dto);
            _repository.Add(entity);
            return entity.Id;
        }

        public bool Update(SystemAccountDTO dto)
        {
            var existing = _repository.GetById(dto.Id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            _repository.Update(existing);
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return false;

            _repository.Delete(id);
            return true;
        }

        public async Task<SystemAccountDTO?> LoginAsync(string email, string password)
        {
            var entity = await _repository.LoginAsync(email, password);
            return entity == null ? null : _mapper.Map<SystemAccountDTO>(entity);
        }
    }
}
