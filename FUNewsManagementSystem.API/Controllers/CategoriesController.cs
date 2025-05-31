using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service) => _service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _service.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _service.Add(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _service.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return result ? NoContent() : BadRequest("Cannot delete: Category is used or not found.");
        }
    }

}
