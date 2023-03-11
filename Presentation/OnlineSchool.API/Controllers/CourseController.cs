using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Course.Commands.AddLesson;
using OnlineSchool.App.Course.Commands.AddModule;
using OnlineSchool.App.Course.Commands.AddTask;
using OnlineSchool.App.Course.Commands.CreateCourse;
using OnlineSchool.App.Course.Commands.Enroll;
using OnlineSchool.App.Course.Queries.GetCourseDetails;
using OnlineSchool.App.Task.Commands.MakeAttempt;
using OnlineSchool.Contracts.Course;
using OnlineSchool.Contracts.Course.Get;
using OnlineSchool.Contracts.Course.Lesson;
using OnlineSchool.Contracts.Course.Module;
using OnlineSchool.Contracts.Course.Task;
using System.Security.Claims;

namespace OnlineSchool.API.Controllers;

[Authorize]
[Route("api/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CourseController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{courseId}")]
	public async Task<IActionResult> GetCourseById(string courseId)
    {
		var queru = new GetCourseDetailsQuery(courseId);

		var courseResult = await _mediator.Send(queru);

        return courseResult.Match(
            course => Ok(_mapper.Map<GetCourseDetailsResponse>(course)),
            errors => Problem("Ошибка")
            );
    }


    [HttpPost("create")]
    [Authorize(Roles = "teacher")]
    public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var command = _mapper.Map<CreateCourseCommand>(request);

        var result = await _mediator.Send(command);

        return result.Match(
            coursesResult => Ok(result.Value),
            errors => Problem("Ошибка")
            );
    }

    [HttpPost("{courseId}/addModule")]
    public async Task<IActionResult> AddModule(string courseId, [FromBody]AddModuleRequest request)
    {
        var command = _mapper.Map<AddModuleCommand>((request, courseId));

        var result = await _mediator.Send(command);

        return result.Match(
            coursesResult => Ok(new AddModuleResponse(result.Value)),
            errors => Problem("Ошибка")
            );
    }

    [HttpPost("module/{moduleId}/addLesson")]
    public async Task<IActionResult> AddLesson(string moduleId, [FromBody]AddLessonRequest request)
    {
        var command = _mapper.Map<AddLessonCommand>((request, moduleId));

        var result = await _mediator.Send(command);

        return result.Match(
            module => Ok(new AddLessonResponse(result.Value)),
            errors => Problem("Ошибка"));
    }

    [HttpPost("lesson/{lessonId}/addTask")]
    public async Task<IActionResult> AddTask(string lessonId, [FromBody]AddTaskRequest request)
    {
        var command = _mapper.Map<AddTaskCommand>((request, lessonId));

        var result = await _mediator.Send(command);

        return result.Match(
            module => Ok(new AddTaskResponse(result.Value)),
            errors => Problem("Ошибка"));
    }

    [HttpPost("task/{taskId}/makeAttempt/{studentId}")]
    public async Task<IActionResult> MakeAttempt(string taskId, string studentId, [FromBody]MakeAttemptRequest request)
    {
        var command = new MakeAttemptCommand(studentId, taskId, request.Answer);
        var resultAttempt = await _mediator.Send(command);

        return resultAttempt.Match(
            resAttempt => Ok(resAttempt),
            errors => Problem("Ошибка"));
    }


    [HttpPost("enroll/{courseId}/{studentId}")]
    public async Task<IActionResult> Enroll(string courseId, string studentId)
    {
        var command = _mapper.Map<EnrollCommand>((studentId, courseId));

        var resultEnroll = await _mediator.Send(command);

        return resultEnroll.Match(
            module => Ok(_mapper.Map<EnrollResponse>(resultEnroll.Value)),
            errors => Problem("Ошибка"));
    }
}