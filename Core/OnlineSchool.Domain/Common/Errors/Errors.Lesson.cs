using ErrorOr;

namespace OnlineSchool.Domain.Common.Errors;

public static partial class Errors
{
    public static class Lesson
    {
        public static Error InvalidId => Error.Validation(
            code: "Lesson.InvalidId",
            description: "Lesson ID was incorrect.");

        public static Error NotFound => Error.NotFound(
            code: "Lesson.NotFound",
            description: "Lesson was not found.");

        public static Error CouldNotSave => Error.Conflict(
            code: "Lesson.CouldNotSave",
            description: "Lesson could not save.");

        public static Error CouldNotFindVideo => Error.Conflict(
            code: "Lesson.CouldNotFindVideo",
            description: "Could not find video in YouTube.");
    }
}