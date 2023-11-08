using ErrorOr;

namespace OnlineSchool.Domain.Common.Errors;

public static partial class Errors
{
    public static class Enroll
    {
        public static Error StudentAlreadyEnroll => Error.Failure(
            code: "Enroll.StudentAlreadyEnroll",
            description: "Student is already enrolled.");

        public static Error CouldNotEnroll => Error.Failure(
            code: "Enroll.CouldNotEnroll",
            description: "Could not enroll.");
    }
}