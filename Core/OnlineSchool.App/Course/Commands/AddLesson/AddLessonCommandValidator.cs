using FluentValidation;

namespace OnlineSchool.App.Course.Commands.AddLesson;

public class AddLessonCommandValidator : AbstractValidator<AddLessonCommand>
{
    public AddLessonCommandValidator()
    {
        RuleFor(lesson => lesson.Name).NotEmpty();
        RuleFor(lesson => lesson.ModuleId).NotEmpty();
    }
}
