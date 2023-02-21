using ErrorOr;

namespace OnlineSchool.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error UserNotFound => Error.NotFound(
                code: "User.NotFound",
                description: "User was not found.");

            public static Error InvalidId => Error.Validation(
                code: "User.InvalidId",
                description: "User ID was incorrect.");
        }
    }
}
