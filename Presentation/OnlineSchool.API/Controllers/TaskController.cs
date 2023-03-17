using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Task.Queries.GetDetailsTask;
using OnlineSchool.App.Task.Queries.GetFirstTask;
using OnlineSchool.Contracts.Course.Task.Get;

namespace OnlineSchool.API.Controllers;

[Route("api/task")]
public class TaskController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public TaskController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{taskId}")]
    public async Task<IActionResult> GetTaskDetails(string taskId)
    {
        var studentId = GetUserId();

        var queru = new GetDetailsTaskQuery(studentId, taskId);

        var taskResult = await _mediator.Send(queru);

        return taskResult.Match(
            task => Ok(_mapper.Map<GetDetailsTaskResponse>(task)),
            errors => Problem("Ошибка")
            );
    }

    [HttpGet("firstLessonTsk/{lessonId}")]
    public async Task<IActionResult> GetFirstTask(string lessonId)
    {
        var studentId = GetUserId();

        var queru = new GetFirstTaskQuery(studentId, lessonId);

        var taskResult = await _mediator.Send(queru);

        return taskResult.Match(
            task => Ok(_mapper.Map<GetDetailsTaskResponse>(task)),
            errors => Problem("Ошибка")
            );
    }
}