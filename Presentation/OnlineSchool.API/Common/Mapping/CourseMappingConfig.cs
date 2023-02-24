using Mapster;
using OnlineSchool.App.Course.Commands.AddLesson;
using OnlineSchool.App.Course.Commands.AddModule;
using OnlineSchool.App.Course.Commands.CreateCourse;
using OnlineSchool.Contracts.Course;
using OnlineSchool.Contracts.Course.Lesson;
using OnlineSchool.Contracts.Course.Module;

namespace OnlineSchool.API.Common.Mapping;

public class CourseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCourseRequest, CreateCourseCommand>();

        config.NewConfig<(AddModuleRequest request, string courseId), AddModuleCommand>()
            .Map(dest => dest.CourseId, src => src.courseId)
            .Map(dest => dest.Name, src => src.request.Name);

        config.NewConfig<(AddLessonRequest request, string moduleId), AddLessonCommand>()
            .Map(dest => dest.ModuleId, src => src.moduleId)
            .Map(dest => dest.Name, src => src.request.Name);
    }
}