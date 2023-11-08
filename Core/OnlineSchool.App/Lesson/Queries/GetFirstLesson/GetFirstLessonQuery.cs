using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Lesson.Queries.GetFirstLesson;

public record GetFirstLessonQuery(
    string CourseId) : IRequest<ErrorOr<LessonVm>>;
