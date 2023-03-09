using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses
{
    public class GetCourseStructureHandler
        : IRequestHandler<GetCourseStructureQuery, ErrorOr<CourseStructureVm>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCourseStructureHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<CourseStructureVm>> Handle(
            GetCourseStructureQuery request,
            CancellationToken cancellationToken)
        {
            //1. Проверяем на корректность ID курса.
            if (!Guid.TryParse(request.CourseID, out var courseId))
            {
                return Errors.Course.InvalidId;
            }

            //2. Проверяем, существует ли данный курс.
            var course = await _unitOfWork.Courses.FindCourseByIdWithModulesLessons(courseId);

            if (course is null)
            {
                return Errors.Course.NotFound;
            }

            var result = new CourseStructureVm(
                course.Id.ToString(),
                course.Name,
                course.Modules/*.OrderBy(module => module.Order)*/
                .Select(module => new ModuleVm(
                    module.Id.ToString(),
                    module.Name,
                    module.Lessons/*.OrderBy(lesson => lesson.Order)*/
                    .Select(lesson => new LessonVm(
                        lesson.Id.ToString(),
                        lesson.Name
                        )).ToList()
                    )).ToList()
                );

            return result;

            
        }
    }
}
