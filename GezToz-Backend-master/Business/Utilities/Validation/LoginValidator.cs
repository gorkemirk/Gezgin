using Business.Models.Request.Functional;
using FluentValidation;

namespace Business.Utilities.Validation;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithName("Email");
        RuleFor(x => x.Password).NotEmpty().WithName("Şifre");
    }
}