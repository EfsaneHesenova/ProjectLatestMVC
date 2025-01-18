using Microsoft.AspNetCore.Mvc;
using ProjectLatest.BL.DTOs.AccountsDtos;
using ProjectLatest.BL.Services.Abstractions;

namespace ProjectLatest.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createDto);
            }
            try
            {
                await _accountService.RegisterAsync(createDto);
                return RedirectToAction(nameof(Index), "Home");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                await _accountService.LoginAsync(loginDto);
                return RedirectToAction(nameof(Index), "Home");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
               await _accountService.LogoutAsync();
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
