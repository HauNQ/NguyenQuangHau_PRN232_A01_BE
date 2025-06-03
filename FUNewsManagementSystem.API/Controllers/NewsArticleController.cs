using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsArticleController : ControllerBase
    {
        private readonly INewsArticleService _service;

        public NewsArticleController(INewsArticleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewsArticleDTO newsDto)
        {
            if (newsDto == null) return BadRequest();
            var id = _service.Add(newsDto);
            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] NewsArticleDTO newsDto)
        {
            if (newsDto == null || id != newsDto.Id) return BadRequest();
            var success = _service.Update(newsDto);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);
            return success ? Ok() : NotFound();
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var result = _service.Search(keyword);
            return Ok(result);
        }
    }
}
