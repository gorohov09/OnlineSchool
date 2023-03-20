namespace OnlineSchool.Contracts.Course.Get;

public record RatingStudentsResponse(
    List<StudentRatingResponse> Students);

public record StudentRatingResponse(
    string StudentId,
    int Order,
    string LastName,
    string FirstName,
    int CountCompleteTask);
