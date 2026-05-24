namespace YetAnotherStore.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
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

        RuleFor(x => x.FullName)
            .MaximumLength(100)
            .WithMessage("{PropertyName} cannot exceed {MaxLength} characters");

        RuleFor(x => x.Gender)
            .IsInEnum()
            .WithMessage("{PropertyName} value {PropertyValue} is invalid");
    }
}
