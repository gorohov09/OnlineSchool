
namespace OnlineSchool.Contracts.Student;

public record CoursesStudentResponse(
    string Id,
    string LastName,
    string FirstName,
    List<CourseResponse> Courses);

public record CourseResponse(
    Guid Id,
    string Name,
    string Description,
    double PersentPassing);
