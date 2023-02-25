using ErrorOr;

namespace OnlineSchool.Domain.Common.Errors;

public static partial class Errors
{       
    public static class Student
    {
        public static Error StudentNotEnrollLesson => Error.Validation(
            code: "Student.StudentNotEnrollLesson",
            description: "Student not enroll lesson.");
    }
}
