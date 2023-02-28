using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses
{
    public class GetCoursesModulesLessonsQueryHandler
        : IRequestHandler<GetCoursesModulesLessonsQuery, ErrorOr<StudentCoursesModulesLessonsVm>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;

        public GetCoursesModulesLessonsQueryHandler(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<StudentCoursesModulesLessonsVm>> Handle(
            GetCoursesModulesLessonsQuery request,
            CancellationToken cancellationToken)
        {
            //1. Проверяем на корректность ID курса.
            if (!Guid.TryParse(request.CourseID, out var courseId))
            {
                return Errors.Course.InvalidId;
            }

            //2. Проверяем, существует ли данный пользователь.
            var course = await _courseRepository.FindCourseWithModulesAndLessonsById(courseId);
            if (course is null)
            {
                return Errors.Course.NotFound;
            }

            var courseInformationAdmission = _courseRepository.GetInformationAdmissionFindCourseWithModulesAndLessonsById(courseId);
            //3. 
            var courseInformation = courseInformationAdmission.Select(course => new CoursesModulesLessonsVm()
            {

            })
        }
    }
}
