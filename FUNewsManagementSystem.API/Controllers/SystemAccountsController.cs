using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAccountsController : ControllerBase
    {
        private readonly ISystemAccountService _service;

        public SystemAccountsController(ISystemAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var accounts = _service.GetAll();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var account = _service.GetById(id);
            return account == null ? NotFound() : Ok(account);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SystemAccountDTO accountDto)
        {
            var id = _service.Add(accountDto);
            return Ok(new { Id = id });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SystemAccountDTO accountDto)
        {
            if (id != accountDto.Id) return BadRequest();
            var success = _service.Update(accountDto);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);
            return success ? Ok() : NotFound();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _service.LoginAsync(dto.Email, dto.Password);
            return user == null ? Unauthorized() : Ok(user);
        }
    }
}
