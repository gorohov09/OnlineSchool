using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Task.Queries.GetDetailsTask;
using OnlineSchool.App.Teacher.Queries.GetAllStudents;

namespace OnlineSchool.API.Controllers;

[Route("api/teacher")]
public class TeacherController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public TeacherController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("allStudentsByTeacher")]
    public async Task<IActionResult> GetAllStudentsByTeacher()
    {
        var teacherId = GetUserId();

        var queru = new GetAllStudentsQuery(teacherId);

        var taskResult = await _mediator.Send(queru);

        return Ok(taskResult.Value);
    }
}