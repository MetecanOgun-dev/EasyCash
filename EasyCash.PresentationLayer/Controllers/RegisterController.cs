using EasyCash.DtoLayer.Dtos.AppUserDtos;
using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    Name = registerDto.Name,
                    Surname = registerDto.Surname
                };
                var result = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmEmail");
                }
            }
            return View();
        }
    }
}
