using Microsoft.AspNetCore.Identity;

namespace EasyCash.PresentationLayer.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber 
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Code = "PasswordTooShort",
				Description = $"Your password must be have at least {length} characters long"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = nameof(PasswordRequiresUpper),
				Description = "Your password must be have at least one uppercase character"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Your password must be have at least one lowercase character"
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Your password must be have at least one digit"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Your password must be have at least one alphanumeric"
			};
		}
	}
}
