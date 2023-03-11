namespace OnlineSchool.Domain.User;

public class UserEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Password { get; }

    public string Email { get; }

    public UserType Type { get; }

    public UserEntity(string firstName, string lastName, string password, string email, UserType userType)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Type = userType;
    }

    public UserEntity()
    {

    }

    public UserType GetTypeUser => Type;

    public string GetUserTypeToString()
    {
        switch (Type)
        {
            case UserType.Teacher:
                return "teacher";
            case UserType.Student:
                return "student";
        }

        return "";
    }
}

public enum UserType
{
    Teacher,
    Student
}
