using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Lesson.Queries.GetLessonDetails;

public record GetLessonDetailsQuery
    (string LessonId) : IRequest<ErrorOr<LessonDetailsVm>>;