using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Student.Queries.GetCourses;
using OnlineSchool.App.Student.Queries.GetLessonTasks;
using OnlineSchool.Contracts.Student;

namespace OnlineSchool.API.Controllers;

[Route("api/student")]
public class StudentController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public StudentController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("courses")]
    public async Task<IActionResult> GetCourses()
    {
        var studentId = GetUserId();

        var queru = new GetCoursesStudentQuery(studentId);

        var coursesResult = await _mediator.Send(queru);

        return coursesResult.Match(
            coursesResult => Ok(_mapper.Map<CoursesStudentResponse>(coursesResult)),
            errors => Problem("Ошибка")
            );
    }

    [HttpGet("{lessonId}/tasks")]
    public async Task<IActionResult> GetTasksLesson(string lessonId)
    {
        var studentId = GetUserId();

        var queru = new GetLessonTasksQuery(studentId, lessonId);

        var tasksLessonResult = await _mediator.Send(queru);

        return tasksLessonResult.Match(
            tasksLessonResult => Ok(_mapper.Map<TasksStudentByLessonResponse>(tasksLessonResult)),
            errors => Problem("Ошибка")
            );
    }
}
