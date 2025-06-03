using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Core.DTOs;
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
        public IActionResult Create([FromBody] TagDTO tagDto)
        {
            var newTagId = _tagService.Add(tagDto);
            return CreatedAtAction(nameof(Get), new { id = newTagId }, tagDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TagDTO tagDto)
        {
            if (id != tagDto.Id) return BadRequest("ID mismatch.");

            var updated = _tagService.Update(tagDto);
            return updated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _tagService.Delete(id);
            return deleted ? Ok() : NotFound();
        }
    }
}
