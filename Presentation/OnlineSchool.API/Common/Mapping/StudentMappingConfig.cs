using Mapster;
using OnlineSchool.App.Student.Queries.GetCourses;
using OnlineSchool.App.Student.Queries.GetLessonTasks;
using OnlineSchool.Contracts.Student;

namespace OnlineSchool.API.Common.Mapping;

public class StudentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CoursesStudentVm, CoursesStudentResponse>();
        config.NewConfig<CourseVm, CourseResponse>();

        config.NewConfig<LessonTasksVm, TasksStudentByLessonResponse>();
        config.NewConfig<TaskResponse, TaskVm>();
    }
}