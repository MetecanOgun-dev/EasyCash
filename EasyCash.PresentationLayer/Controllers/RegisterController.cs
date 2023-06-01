using EasyCash.DtoLayer.Dtos.AppUserDtos;
using EasyCash.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;


namespace EasyCash.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

		public RegisterController(UserManager<AppUser> userManager, IConfiguration configuration) 
		{
			_configuration = configuration;
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
                Random random = new Random();
                int emailValidationCode = random.Next(100000, 1000000);

				AppUser appUser = new AppUser()
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    Name = registerDto.Name,
                    Surname = registerDto.Surname,
                    District= "Test",
                    City = "Test",
                    ImageUrl = "Test",
                    EmailValidationCode = emailValidationCode
                };
                var result = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (result.Succeeded)
                {
                    var mailSender = _configuration.GetValue<string>("Mailservice:Sender");
                    var mailSenderPassword = _configuration.GetValue<string>("Mailservice:SenderPassword");
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAdressFrom = new MailboxAddress("Easy Cash Admin", mailSender);
                    MailboxAddress mailboxAdressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAdressFrom);
                    mimeMessage.To.Add(mailboxAdressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = EmailConfirmationMessage(appUser.UserName, emailValidationCode);
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash - Email Verification Code";

                    MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate(mailSender, mailSenderPassword);
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    TempData["UserEmail"] = appUser.Email;

					return RedirectToAction("Index", "EmailValidation");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        private string EmailConfirmationMessage(string username, int emailValidationCode)
        {
            var emailConfirmationText =
				$"Dear {username},\n\n" +
	            "Please find your verification code below:\n\n" +
	            $"Verification Code: {emailValidationCode}\n\n" +
	            "To complete the email validation process, kindly enter the provided verification code in the designated field on our website.\n\n" +
				"If you did not initiate this email validation or have any concerns, please disregard this message. For any assistance or questions, feel free to contact our support team at fakemail@easycash.com\n\n" +
	            "Thank you for your cooperation.\n\n" +
	            "Best regards,\n\n" +
	            "Easy Cash\n" +
				"fakemail@easycash.com";

            return emailConfirmationText;
		}
    }
}
