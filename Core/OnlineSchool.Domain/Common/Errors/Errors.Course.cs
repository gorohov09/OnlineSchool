using ErrorOr;

namespace OnlineSchool.Domain.Common.Errors;

public static partial class Errors
{
    public static class Course
    {
        public static Error InvalidId => Error.Validation(
            code: "Course.InvalidId",
            description: "Course ID was incorrect.");

        public static Error NotFound => Error.NotFound(
            code: "Course.NotFound",
            description: "Course was not found.");

        public static Error CouldNotSave => Error.Conflict(
            code: "Course.CouldNotSave",
            description: "Course could not save.");
    }
}