using FluentValidation;

namespace Projectify.Application.Projects.Commands.Create;

internal sealed class CreateProjectCommandValidator
    : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Deadline.Date)
            .GreaterThan(DateTime.Now.Date);
    }
}