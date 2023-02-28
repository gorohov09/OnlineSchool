using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses
{
    public class GetCoursesModulesLessonsQueryHandler
        : IRequestHandler<GetCourseStructureQuery, ErrorOr<CourseStructureVm>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesModulesLessonsQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        //public Task<ErrorOr<CourseStructureVm>> Handle(GetCourseStructureQuery request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<ErrorOr<CourseStructureVm>> Handle(
            GetCourseStructureQuery request,
            CancellationToken cancellationToken)
        {
            //1. Проверяем на корректность ID курса.
            if (!Guid.TryParse(request.CourseID, out var courseId))
            {
                return Errors.Course.InvalidId;
            }

            //2. Проверяем, существует ли данный rehc.
            var course = await _courseRepository.FindCourseWithModulesAndLessonsById(courseId);
            if (course is null)
            {
                return Errors.Course.NotFound;
            }

            var result = new CourseStructureVm(
                course.Id,
                course.Name,
                course.Modules.OrderBy(module => module.Order)
                .Select(module => new ModuleVm(
                    module.Id,
                    module.Name,
                    module.Lessons.OrderBy(lesson => lesson.Order)
                    .Select(lesson => new LessonVm(
                        lesson.Id,
                        lesson.Name
                        )).ToList()
                    )).ToList()
                );

            return result;

            
        }
    }
}
