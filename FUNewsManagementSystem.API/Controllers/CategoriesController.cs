using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
        public IActionResult Create(CategoryDTO category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            category = _service.GetById(_service.Add(category));

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryDTO category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (category.Id != id) return BadRequest("ID mismatch");

            bool success = _service.Update(category);

            if (!success) return NotFound();

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
