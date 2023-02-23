using Mapster;
using OnlineSchool.App.Student.Queries.GetCourses;
using OnlineSchool.Contracts.Student;

namespace OnlineSchool.API.Common.Mapping;

public class StudentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CoursesStudentVm, CoursesStudentResponse>();
        config.NewConfig<CourseVm, CourseResponse>();
    }
}