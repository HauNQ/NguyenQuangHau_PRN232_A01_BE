using FUNewsManagementSystem.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using NguyenQuangHau_PRN232_A01_BE.FrontEnd.Models;
using System.Diagnostics;

namespace NguyenQuangHau_PRN232_A01_BE.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TagTest()
        {
            return View(_httpClient.GetFromJsonAsync<IEnumerable<TagDTO>>("Tag"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
