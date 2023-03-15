using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Lesson.Queries.GetLessonDetails;
using OnlineSchool.Contracts.Course.Lesson;

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

    [HttpGet("{lessonId}")]
    public async Task<IActionResult> GetLessonById(string lessonId)
    {
        var queru = new GetLessonDetailsQuery(lessonId);

        var lessonResult = await _mediator.Send(queru);

        return lessonResult.Match(
            course => Ok(_mapper.Map<GetLessonDetailsResponse>(course)),
            errors => Problem("Ошибка")
            );
    }
}


