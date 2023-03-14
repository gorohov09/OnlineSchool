using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineSchool.API.Controllers;

[Route("api/lesson")]
public class LessonController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public LessonController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    //[HttpGet("{lessonId}")]
    //public async Task<IActionResult> GetLessonById(string lessonId)
    //{
    //    //var queru = new GetCourseDetailsQuery(lessonId);

    //    //var courseResult = await _mediator.Send(queru);

    //    //return courseResult.Match(
    //    //    course => Ok(_mapper.Map<GetCourseDetailsResponse>(course)),
    //    //    errors => Problem("Ошибка")
    //    //    );
    //}
}


