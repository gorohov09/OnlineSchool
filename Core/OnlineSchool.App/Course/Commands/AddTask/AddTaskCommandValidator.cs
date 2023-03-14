using FluentValidation;

namespace OnlineSchool.App.Course.Commands.AddTask;

public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
{
    public AddTaskCommandValidator()
    {
        RuleFor(task => task.LessonId).NotEmpty();
        RuleFor(task => task.Name).NotEmpty();
        RuleFor(task => task.Description).NotEmpty();
        RuleFor(task => task.Answer).NotEmpty();
        RuleFor(task => task.Question).NotEmpty();
    }
}