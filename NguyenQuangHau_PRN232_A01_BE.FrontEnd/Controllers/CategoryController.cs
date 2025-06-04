using FUNewsManagementSystem.Core.DTOs;
using Microsoft.AspNetCore.Mvc;


public class CategoryController : Controller
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetCategoriesAsync();
        return View(categories);
    }

    public async Task<IActionResult> Details(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO category)
    {
        if (!ModelState.IsValid) return View(category);
        var success = await _categoryService.CreateCategoryAsync(category);
        if (!success) ModelState.AddModelError("", "Failed to create category.");
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, CategoryDTO category)
    {
        if (id != category.Id) return BadRequest();
        if (!ModelState.IsValid) return View(category);

        var success = await _categoryService.UpdateCategoryAsync(id, category);
        if (!success) return NotFound();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var success = await _categoryService.DeleteCategoryAsync(id);
        if (!success) return BadRequest("Delete failed.");
        return RedirectToAction(nameof(Index));
    }
}
