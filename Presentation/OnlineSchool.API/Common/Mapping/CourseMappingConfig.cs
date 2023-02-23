using Mapster;
using OnlineSchool.App.Course.Commands.CreateCourse;
using OnlineSchool.Contracts.Course;

namespace OnlineSchool.API.Common.Mapping;

public class CourseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCourseRequest, CreateCourseCommand>();
    }
}