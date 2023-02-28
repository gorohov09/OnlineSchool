using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;

namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses
{
    public class GetCoursesModulesLessonsQueryHandler
        : IRequestHandler<GetCoursesModulesLessonsQuery, ErrorOr<CoursesModulesLessonsVm>>
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;

        public GetCoursesModulesLessonsQueryHandler(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }
        public Task<ErrorOr<CoursesModulesLessonsVm>> Handle(GetCoursesModulesLessonsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
