using BuyMe.Domain.DTO;
using BuyMe.Domain.Interfaces.Application;
using FluentValidation;

namespace BuyMe.Presentation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(IAccountService service)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                if (service.CheckEmail(value))
                {
                    context.AddFailure("Email", "That email is taken.");
                }
            });
        }
    }
}
