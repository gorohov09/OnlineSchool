using MapsterMapper;
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
    private readonly IMapper _mapper;

    public CourseController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
    {
        var command = _mapper.Map<CreateCourseCommand>(request);

        var result = await _mediator.Send(command);

        return result.Match(
            coursesResult => Ok(result.Value),
            errors => Problem("Ошибка")
            );
    }
}