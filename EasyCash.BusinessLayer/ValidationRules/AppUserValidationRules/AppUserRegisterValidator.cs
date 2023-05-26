using EasyCash.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator() {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please enter your name.")
                .MinimumLength(6).WithMessage("Minimum 6 characters allowed")
                .MaximumLength(30).WithMessage("Maximum 30 characters allowed"); 

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Please enter your surname.")
                .MinimumLength(6).WithMessage("Minimum 6 characters allowed")
                .MaximumLength(30).WithMessage("Maximum 30 characters allowed"); 

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Please enter your username.")
                .MinimumLength(6).WithMessage("Minimum 6 characters allowed")
                .MaximumLength(30).WithMessage("Maximum 30 characters allowed"); 

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email.")
                .EmailAddress().WithMessage("Please enter a valid email adress.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please enter your password.")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.)."); ;
          
            
            RuleFor(x => x.ConfirmPassword)
                .Equal(y=>y.Password).WithMessage("Passwords must match.");

        }
    }
}
