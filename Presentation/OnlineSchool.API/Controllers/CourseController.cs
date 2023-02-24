using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Course.Commands.AddLesson;
using OnlineSchool.App.Course.Commands.AddModule;
using OnlineSchool.App.Course.Commands.CreateCourse;
using OnlineSchool.Contracts.Course;
using OnlineSchool.Contracts.Course.Lesson;
using OnlineSchool.Contracts.Course.Module;

namespace OnlineSchool.API.Controllers;

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

    [HttpPost("create")]
    public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
    {
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
}