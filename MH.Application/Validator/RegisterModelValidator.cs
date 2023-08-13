using FluentValidation;
using MH.Domain.Model;

namespace MH.Application.Validator;

public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator()
    {
        
        RuleFor(registerModel => registerModel.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage("First name must not be empty");
        
        RuleFor(registerModel => registerModel.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Last name must not be empty");
        
        RuleFor(registerModel => registerModel.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email must not be empty");
        
        RuleFor(registerModel => registerModel.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage("Phone number must not be empty");
        
        RuleFor(registerModel => registerModel.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Password must not be empty");
    }
}