namespace OnlineSchool.Contracts.Course;

public record CreateCourseRequest(
    string Name,
    string Description);