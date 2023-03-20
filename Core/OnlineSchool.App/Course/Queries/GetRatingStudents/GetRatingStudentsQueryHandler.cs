using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Queries.GetRatingStudents;

public class GetRatingStudentsQueryHandler
    : IRequestHandler<GetRatingStudentsQuery, ErrorOr<RatingStudentsVm>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRatingStudentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<RatingStudentsVm>> Handle(GetRatingStudentsQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.CourseId, out var courseId))
        {
            return Errors.Course.InvalidId;
        }

        var studentsByCourse = await _unitOfWork.StudentCourses.GetRatingStudentCourseInformationsWithStudentByCourseId(courseId);

        var resultList = new List<StudentRatingVm>();

        int order = 1;
        foreach (var studentCourseInf in studentsByCourse)
        {
            resultList.Add(
                new StudentRatingVm(
                    studentCourseInf.Student.Id.ToString(),
                    order,
                    studentCourseInf.Student.LastName,
                    studentCourseInf.Student.FirstName,
                    studentCourseInf.CountCompletedTasks
                ));
            order++;
        }

        return new RatingStudentsVm(resultList);
    }
}