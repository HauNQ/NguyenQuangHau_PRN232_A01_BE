using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAccountsController : ControllerBase
    {
        private readonly ISystemAccountRepository _repo;

        public SystemAccountsController(ISystemAccountRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var acc = await _repo.GetByIdAsync(id);
            return acc == null ? NotFound() : Ok(acc);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SystemAccount acc)
        {
            await _repo.AddAsync(acc);
            return CreatedAtAction(nameof(GetById), new { id = acc.Id }, acc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SystemAccount acc)
        {
            if (id != acc.Id) return BadRequest();
            return await _repo.UpdateAsync(acc) ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _repo.DeleteAsync(id) ? Ok() : Conflict("Cannot delete an account that has created news.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _repo.LoginAsync(dto.Email, dto.Password);
            return user == null ? Unauthorized() : Ok(user);
        }
    }

}
