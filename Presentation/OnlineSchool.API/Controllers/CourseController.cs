using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Course.Commands.AddLesson;
using OnlineSchool.App.Course.Commands.AddModule;
using OnlineSchool.App.Course.Commands.AddTask;
using OnlineSchool.App.Course.Commands.CreateCourse;
using OnlineSchool.App.Course.Commands.Enroll;
using OnlineSchool.App.Course.Queries.GetAllCourses;
using OnlineSchool.App.Course.Queries.GetCourseDetails;
using OnlineSchool.App.Course.Queries.GetPopularCourses;
using OnlineSchool.App.Task.Commands.MakeAttempt;
using OnlineSchool.Contracts.Course;
using OnlineSchool.Contracts.Course.Get;
using OnlineSchool.Contracts.Course.Lesson;
using OnlineSchool.Contracts.Course.Module;
using OnlineSchool.Contracts.Course.Task;
using System.Security.Claims;

namespace OnlineSchool.API.Controllers;


[Route("api/course")]
public class CourseController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CourseController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Также выводится информация о результатах пользователя по курсу
    /// </summary>
    /// <param name="courseId"></param>
    /// <returns></returns>
    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourseById(string courseId)
    {
        var userId = GetUserId();

        var queru = new GetCourseDetailsQuery(courseId, userId);

        var courseResult = await _mediator.Send(queru);

        return courseResult.Match(
            course => Ok(_mapper.Map<GetCourseDetailsResponse>(course)),
            errors => Problem("Ошибка")
            );
    }

    [HttpGet("teacherCourses")]
    public async Task<IActionResult> GetTeacherCourses()
    {
        var teacherId = GetUserId();

        var queru = new GetTeacherCoursesQuery(teacherId);

        var coursesResult = await _mediator.Send(queru);

		return coursesResult.Match(
			course => Ok(_mapper.Map<GetTeacherCoursesResponse>(course)),
			errors => Problem("Ошибка")
			);
	}

    [HttpGet("popularCourses")]
    public async Task<IActionResult> GetPopularCourses()
    {
        var studentId = GetUserId();

        var queru = new GetPopularCoursesQuery(studentId);

        var coursesResult = await _mediator.Send(queru);

        return coursesResult.Match(
            course => Ok(_mapper.Map<GetPopularCoursesResponse>(course)),
            errors => Problem("Ошибка")
            );
    }


    [HttpPost("create")]
    [Authorize(Roles = "teacher")]
    public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
    {
        var teacherId = GetUserId();

        var command = _mapper.Map<CreateCourseCommand>((request, teacherId));

        var result = await _mediator.Send(command);

        return result.Match(
            coursesResult => Ok(result.Value),
            errors => Problem("Ошибка")
            );
    }

    [HttpPost("{courseId}/addModule")]
    [Authorize(Roles = "teacher")]
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
    [Authorize(Roles = "teacher")]
    public async Task<IActionResult> AddLesson(string moduleId, [FromBody]AddLessonRequest request)
    {
        var command = _mapper.Map<AddLessonCommand>((request, moduleId));

        var result = await _mediator.Send(command);

        return result.Match(
            module => Ok(new AddLessonResponse(result.Value)),
            errors => Problem("Ошибка"));
    }

    [HttpPost("lesson/{lessonId}/addTask")]
    [Authorize(Roles = "teacher")]
    public async Task<IActionResult> AddTask(string lessonId, [FromBody]AddTaskRequest request)
    {
        var command = _mapper.Map<AddTaskCommand>((request, lessonId));

        var result = await _mediator.Send(command);

        return result.Match(
            module => Ok(new AddTaskResponse(result.Value)),
            errors => Problem("Ошибка"));
    }

    [HttpPost("task/{taskId}/makeAttempt")]
    public async Task<IActionResult> MakeAttempt(string taskId, [FromBody]MakeAttemptRequest request)
    {
        var studentId = GetUserId();

        var command = new MakeAttemptCommand(studentId, taskId, request.Answer);
        var resultAttempt = await _mediator.Send(command);

        return resultAttempt.Match(
            resAttempt => Ok(resAttempt),
            errors => Problem("Ошибка"));
    }


    [HttpPost("enroll/{courseId}")]
    public async Task<IActionResult> Enroll(string courseId)
    {
        var studentId = GetUserId();

        var command = _mapper.Map<EnrollCommand>((studentId, courseId));

        var resultEnroll = await _mediator.Send(command);

        return resultEnroll.Match(
            module => Ok(_mapper.Map<EnrollResponse>(resultEnroll.Value)),
            errors => Problem("Ошибка"));
    }
}