using FluentValidation;

namespace OnlineSchool.App.Course.Commands.Enroll;

public class EnrollCommandValidator : AbstractValidator<EnrollCommand>
{
    public EnrollCommandValidator()
    {
        RuleFor(enroll => enroll.CourseId).NotEmpty();
        RuleFor(enroll => enroll.StudentId).NotEmpty();
    }
}