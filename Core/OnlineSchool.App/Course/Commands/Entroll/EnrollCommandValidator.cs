using FluentValidation;

namespace OnlineSchool.App.Course.Commands.Entroll;

public class EnrollCommandValidator : AbstractValidator<EnrollCommand>
{
    public EnrollCommandValidator()
    {
        RuleFor(enroll => enroll.CourseId).NotEmpty();
        RuleFor(enroll => enroll.StudentId).NotEmpty();
    }
}