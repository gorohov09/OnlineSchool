using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Domain.Course;

namespace OnlineSchool.App.Course.Commands.CreateCourse;

public class CreateCourseCommandHandler
    : IRequestHandler<CreateCourseCommand, ErrorOr<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork; 
    }

    public async Task<ErrorOr<bool>> Handle(
        CreateCourseCommand request, 
        CancellationToken cancellationToken)
    {
        //1. Создаем курс
        var course = new CourseEntity(request.Name, request.Description);

        //2. Добавляем курс в хранилище
        if (await _unitOfWork.Courses.Add(course))
            return await _unitOfWork.CompleteAsync();

        return false;
    }
}
