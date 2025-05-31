using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Core.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewsArticle news)
        {
            _service.Add(news);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] NewsArticle news)
        {
            if (id != news.Id) return BadRequest();
            _service.Update(news);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            return Ok(_service.Search(keyword));
        }
    }

}
