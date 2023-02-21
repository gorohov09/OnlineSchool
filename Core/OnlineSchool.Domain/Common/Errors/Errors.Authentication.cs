using ErrorOr;

namespace OnlineSchool.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCred",
                description: "Invalid credentials.");

            public static Error DuplicateEmail => Error.Validation(
                code: "Auth.DupEmail",
                description: "This user already exists");
        }
    }
}
