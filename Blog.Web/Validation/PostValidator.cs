using Blog.Web.Models;
using FluentValidation;

namespace Blog.Web.Validation;

public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required");
        
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required");
    }
}