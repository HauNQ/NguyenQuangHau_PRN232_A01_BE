using Microsoft.AspNetCore.Mvc;

namespace NguyenQuangHau_PRN232_A01_BE.FrontEnd.Controllers
{
    using FUNewsManagementSystem.Core.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using NguyenQuangHau_PRN232_A01_BE.FrontEnd.Service;
    using System.Threading.Tasks;

    public class SystemAccountController : Controller
    {
        private readonly SystemAccountService _service;

        public SystemAccountController(SystemAccountService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _service.GetAllAsync();
            return View(accounts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var account = await _service.GetByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(SystemAccountDTO account)
        {
            if (!ModelState.IsValid) return View(account);

            var success = await _service.CreateAsync(account);
            if (!success) ModelState.AddModelError("", "Creation failed.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var account = await _service.GetByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SystemAccountDTO account)
        {
            if (id != account.Id) return BadRequest();
            if (!ModelState.IsValid) return View(account);

            var success = await _service.UpdateAsync(id, account);
            if (!success) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var account = await _service.GetByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? RedirectToAction(nameof(Index)) : BadRequest("Delete failed.");
        }
    }

}
