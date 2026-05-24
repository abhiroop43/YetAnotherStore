namespace YetAnotherStore.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        const string requiredValidationMessage = "{PropertyName} cannot be null";

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(requiredValidationMessage)
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(requiredValidationMessage)
            .MinimumLength(8)
            .WithMessage("{PropertyName} must be at least {MinLength} characters")
            .MaximumLength(15)
            .WithMessage("{PropertyName} cannot exceed {MaxLength} characters");
    }
}
