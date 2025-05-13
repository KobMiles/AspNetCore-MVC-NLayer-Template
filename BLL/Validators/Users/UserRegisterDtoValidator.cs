using BLL.DTOs.Users;
using FluentValidation;

namespace BLL.Validators.Users;

public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100).WithMessage("The name must be less than 100 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .MaximumLength(100).WithMessage("The last name must be less than 100 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Passwords do not match.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^(?:\+\d{1,3}[- ]?)?\d{9,10}$")
            .WithMessage("Invalid phone number format.");
    }
}