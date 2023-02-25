using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Student.Queries;
using OnlineSchool.App.Student.Queries.GetCourses;
using OnlineSchool.Contracts.Student;

namespace OnlineSchool.API.Controllers;

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

    private CoursesStudentResponse Map(CoursesStudentVm courses)
    {
        return new CoursesStudentResponse(
            courses.Id,
            courses.LastName,
            courses.FirstName,
            courses.Courses.Select(c => new CourseResponse(c.Id, c.Name, c.Description, c.PersentPassing))
            .ToList());
    }
}
