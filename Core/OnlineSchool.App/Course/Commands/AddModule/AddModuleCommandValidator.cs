using FluentValidation;

namespace OnlineSchool.App.Course.Commands.AddModule;

public class AddModuleCommandValidator : AbstractValidator<AddModuleCommand>
{
    public AddModuleCommandValidator()
    {
        RuleFor(module => module.Name).NotEmpty();
        RuleFor(module => module.CourseId).NotEmpty();
    }
}