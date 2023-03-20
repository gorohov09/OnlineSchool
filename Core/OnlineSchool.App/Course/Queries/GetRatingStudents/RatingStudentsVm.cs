namespace OnlineSchool.App.Course.Queries.GetRatingStudents;

public record RatingStudentsVm(
    List<StudentRatingVm> Students);

public record StudentRatingVm(
    string StudentId,
    int Order,
    string LastName,
    string FirstName,
    int CountCompleteTask);