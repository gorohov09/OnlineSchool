using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Queries.GetRatingStudents;

public record GetRatingStudentsQuery(
    string CourseId) : IRequest<ErrorOr<RatingStudentsVm>>;