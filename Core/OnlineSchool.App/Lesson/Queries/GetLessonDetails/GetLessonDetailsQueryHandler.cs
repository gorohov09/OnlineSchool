using ErrorOr;
using MediatR;
using Newtonsoft.Json;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Lesson.Queries.GetLessonDetails;

public class GetLessonDetailsQueryHandler
        : IRequestHandler<GetLessonDetailsQuery, ErrorOr<LessonDetailsVm>>
{
    private readonly ILessonRepository _lessonRepository;

    public GetLessonDetailsQueryHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<ErrorOr<LessonDetailsVm>> Handle(GetLessonDetailsQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.LessonId, out var lessonId))
        {
            return Errors.Lesson.InvalidId;
        }

        var lesson = await _lessonRepository.FindLessonByIdWithTasks(lessonId);

        if (lesson is null)
            return Errors.Lesson.NotFound;

        return new LessonDetailsVm(
            lesson.Id.ToString(), 
            lesson.Name, lesson.VideoEmbedCode, 
            GetTaskByLesson(lesson));
    }

    private List<TaskVm> GetTaskByLesson(LessonEntity lesson)
    {
        var tasks = new List<TaskVm>();
        foreach (var taskEntity in lesson.Tasks)
        {
            var taskInform = JsonConvert.DeserializeObject<TaskInformation>(taskEntity.TaskInformation);
            tasks.Add(new TaskVm(
                taskEntity.Id.ToString(), 
                taskEntity.Order, 
                taskInform.GetTypeTask(), 
                taskInform.Name, 
                taskInform.Description,
                taskInform.Question, taskInform.Answer.Value));
        }

        return tasks;
    }
}
