using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course;

namespace OnlineSchool.App.Course.Commands.CreateCourse;

public class CreateCourseCommandHandler
    : IRequestHandler<CreateCourseCommand, ErrorOr<bool>>
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<bool>> Handle(
        CreateCourseCommand request, 
        CancellationToken cancellationToken)
    {
        //1. Создаем курс
        var course = new CourseEntity(request.Name, request.Description);

        //2. Добавляем курс в хранилище
        if (await _courseRepository.AddCourse(course))
            return true;

        return false;
    }
}
