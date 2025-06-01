using FUNewsManagementSystem.Application.Services;
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
        public IActionResult Create([FromBody] SystemAccount account)
        {
            _service.Add(account);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SystemAccount account)
        {
            if (id != account.Id) return BadRequest();
            _service.Update(account);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }

}
