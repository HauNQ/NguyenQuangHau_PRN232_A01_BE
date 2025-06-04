namespace NguyenQuangHau_PRN232_A01_BE.FrontEnd.Service
{
    using FUNewsManagementSystem.Core.DTOs;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class SystemAccountService
    {
        private readonly HttpClient _httpClient;

        public SystemAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SystemAccountDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SystemAccountDTO>>("SystemAccounts");
        }

        public async Task<SystemAccountDTO?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<SystemAccountDTO>($"SystemAccounts/{id}");
        }

        public async Task<bool> CreateAsync(SystemAccountDTO account)
        {
            var response = await _httpClient.PostAsJsonAsync("SystemAccounts", account);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, SystemAccountDTO account)
        {
            var response = await _httpClient.PutAsJsonAsync($"SystemAccounts/{id}", account);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"SystemAccounts/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<SystemAccountDTO?> LoginAsync(string email, string password)
        {
            var loginDto = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("SystemAccounts/login", loginDto);

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<SystemAccountDTO>();
        }
    }

}
