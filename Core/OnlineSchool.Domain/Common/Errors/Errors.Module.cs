using ErrorOr;

namespace OnlineSchool.Domain.Common.Errors;

public static partial class Errors
{
    public static class Module
    {
        public static Error InvalidId => Error.Validation(
            code: "Module.InvalidId",
            description: "Module ID was incorrect.");

        public static Error NotFound => Error.NotFound(
            code: "Module.NotFound",
            description: "Module was not found.");

        public static Error CouldNotSave => Error.Conflict(
            code: "Module.CouldNotSave",
            description: "Module could not save.");
    }
}