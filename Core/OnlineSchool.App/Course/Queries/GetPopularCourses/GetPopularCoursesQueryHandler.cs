using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Queries.GetPopularCourses;

public class GetPopularCoursesQueryHandler
    : IRequestHandler<GetPopularCoursesQuery, ErrorOr<PopularCoursesVm>>
{
    private readonly ICourseRepository _courseRepository;

    public GetPopularCoursesQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<PopularCoursesVm>> Handle(GetPopularCoursesQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.StudentId, out var studentId))
        {
            return Errors.User.InvalidId;
        }

        var courses = await _courseRepository.FindPopularCoursesWithModulesLessonsTasksStudents();

        var result = new PopularCoursesVm(
            courses.Select(course => new PopularCourseVm(
                course.Id.ToString(), 
                course.Name, 
                course.Description,
                course.GetCountStudents(), 
                course.GetCountTasks(), 
                course.IsEnrollStudent(studentId))).ToList());

        return result;
    }
}