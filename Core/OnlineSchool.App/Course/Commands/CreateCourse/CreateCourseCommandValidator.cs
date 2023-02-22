using FluentValidation;

namespace OnlineSchool.App.Course.Commands.CreateCourse;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(course => course.Name).NotEmpty();
        RuleFor(course => course.Description).NotEmpty();
    }
}