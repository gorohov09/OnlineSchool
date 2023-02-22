using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Course.Commands.CreateCourse;
using OnlineSchool.Contracts.Course;

namespace OnlineSchool.API.Controllers;

[Route("api/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ISender _mediator;

    public CourseController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
    {
        var command = new CreateCourseCommand(request.Name, request.Description);

        var result = await _mediator.Send(command);

        return result.Match(
            coursesResult => Ok(result.Value),
            errors => Problem("Ошибка")
            );
    }
}