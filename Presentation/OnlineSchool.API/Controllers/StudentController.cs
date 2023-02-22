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

    public StudentController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{studentId}/courses")]
    public async Task<IActionResult> GetCoursest(string studentId)
    {
        var queru = new GetCoursesStudentQuery(studentId);

        var coursesResult = await _mediator.Send(queru);

        return coursesResult.Match(
            coursesResult => Ok(Map(coursesResult)),
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
