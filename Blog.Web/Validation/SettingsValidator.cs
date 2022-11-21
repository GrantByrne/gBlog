using Blog.Web.Models;
using FluentValidation;

namespace Blog.Web.Validation;

public class SettingsValidator : AbstractValidator<Settings>
{
    public SettingsValidator()
    {
        RuleFor(x => x.BlogName)
            .NotEmpty()
            .WithMessage("Name is required");
    }
}