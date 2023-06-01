using EasyCash.EntityLayer.Concrete;
using EasyCash.PresentationLayer.Models;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class EmailValidationController : Controller
    {
        private readonly UserManager<AppUser> _userManagager;

        public EmailValidationController(UserManager<AppUser> userManagager)
        {
            _userManagager = userManagager;
        }

        [HttpGet]
        public IActionResult Index(bool? isvalidated)
        {
            if (isvalidated == null)
            {
                ViewBag.ValidationSuccess = null;
                ViewBag.ValidationMessage = "";
                return View();
            }
            if (isvalidated == false)
            {
                ViewBag.ValidationSuccess = false;
                ViewBag.ValidationMessage = "You have entered wrong verification code.";
                return View();
            }
            if (isvalidated == true)
            {
                ViewBag.ValidationSuccess = true;
                ViewBag.ValidationMessage = "Validation successful. Redirecting to homepage...";
                //Will redirect to homepage with JS
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(EmailValidationViewModel emailValidationViewModel)
        {            
            var userEmail = TempData["UserEmail"].ToString();
            var user = await _userManagager.FindByEmailAsync(userEmail);

            if(user.EmailValidationCode == emailValidationViewModel.ValidationCode)
            {
                return RedirectToAction("Index", "EmailValidation", new { isvalidated = true });
            }
            else
            {
                return RedirectToAction("Index", "EmailValidation", new { isvalidated = false });
            }
        }
    }
}
