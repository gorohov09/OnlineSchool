using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Lesson.Queries.GetFirstLesson;

public class GetFirstLessonQueryHandler
    : IRequestHandler<GetFirstLessonQuery, ErrorOr<LessonVm>>
{
    private readonly ILessonRepository _lessonRepository;

    public GetFirstLessonQueryHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<ErrorOr<LessonVm>> Handle(GetFirstLessonQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.CourseId, out var courseId))
        {
            return Errors.Course.InvalidId;
        }

        var lesson = await _lessonRepository.FindFirstLessonByCourse(courseId);

        if (lesson is null)
            return Errors.Lesson.NotFound;

        return new LessonVm(lesson.Id.ToString(), lesson.Name, lesson.VideoEmbedCode);
    }
}
