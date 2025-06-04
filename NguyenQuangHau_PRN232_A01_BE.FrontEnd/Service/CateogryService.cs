using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FUNewsManagementSystem.Core.DTOs;

public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDTO>>("api/categories");
    }

    public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<CategoryDTO>($"api/categories/{id}");
    }

    public async Task<bool> CreateCategoryAsync(CategoryDTO category)
    {
        var response = await _httpClient.PostAsJsonAsync("api/categories", category);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCategoryAsync(int id, CategoryDTO category)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/categories/{id}", category);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/categories/{id}");
        return response.IsSuccessStatusCode;
    }
}
