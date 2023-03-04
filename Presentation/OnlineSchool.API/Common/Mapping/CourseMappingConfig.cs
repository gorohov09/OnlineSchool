using Mapster;
using OnlineSchool.App.Course.Commands.AddLesson;
using OnlineSchool.App.Course.Commands.AddModule;
using OnlineSchool.App.Course.Commands.AddTask;
using OnlineSchool.App.Course.Commands.CreateCourse;
using OnlineSchool.App.Course.Commands.Entroll;
using OnlineSchool.Contracts.Course;
using OnlineSchool.Contracts.Course.Lesson;
using OnlineSchool.Contracts.Course.Module;
using OnlineSchool.Contracts.Course.Task;

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
            .Map(dest => dest.LinkVideo, src => src.request.LinkVideo)
            .Map(dest => dest.Name, src => src.request.Name);

        config.NewConfig<(AddTaskRequest request, string lessonId), AddTaskCommand>()
            .Map(dest => dest.LessonId, src => src.lessonId)
            .Map(dest => dest.Name, src => src.request.Name)
            .Map(dest => dest.Description, src => src.request.Description)
            .Map(dest => dest.RightAnswer, src => src.request.RightAnswer)
            .Map(dest => dest.Question, src => src.request.Question)
            .Map(dest => dest.TaskType, src => src.request.TaskType);

        config.NewConfig<(string studentId, string courseId), EnrollCommand>()
            .Map(dest => dest.StudentId, src => src.studentId)
            .Map(dest => dest.CourseId, src => src.courseId);

        config.NewConfig<EnrollResult, EnrollResponse>()
            .Map(dest => dest.CourseId, src => src.CourseId)
            .Map(dest => dest.IsSuccess, src => src.IsSuccess);
    }
}