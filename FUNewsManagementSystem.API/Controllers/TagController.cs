using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = _tagService.GetAll();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tag = _tagService.GetById(id);
            return tag == null ? NotFound() : Ok(tag);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tag tag)
        {
            _tagService.Add(tag);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Tag tag)
        {
            if (id != tag.Id) return BadRequest();
            _tagService.Update(tag);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tagService.Delete(id);
            return Ok();
        }
    }
}
