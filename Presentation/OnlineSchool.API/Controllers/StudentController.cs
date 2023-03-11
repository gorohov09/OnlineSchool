using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Student.Queries.GetCourses;
using OnlineSchool.App.Student.Queries.GetLessonTasks;
using OnlineSchool.Contracts.Student;

namespace OnlineSchool.API.Controllers;

[Authorize]
[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public StudentController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{studentId}/courses")]
    public async Task<IActionResult> GetCourses(string studentId)
    {
        var queru = new GetCoursesStudentQuery(studentId);

        var coursesResult = await _mediator.Send(queru);

        return coursesResult.Match(
            coursesResult => Ok(_mapper.Map<CoursesStudentResponse>(coursesResult)),
            errors => Problem("Ошибка")
            );
    }

    [HttpGet("{studentId}/{lessonId}/tasks")]
    public async Task<IActionResult> GetTasksLesson(string studentId, string lessonId)
    {
        var queru = new GetLessonTasksQuery(studentId, lessonId);

        var tasksLessonResult = await _mediator.Send(queru);

        return tasksLessonResult.Match(
            tasksLessonResult => Ok(_mapper.Map<TasksStudentByLessonResponse>(tasksLessonResult)),
            errors => Problem("Ошибка")
            );
    }
}
