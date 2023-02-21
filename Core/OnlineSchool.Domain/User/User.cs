namespace OnlineSchool.Domain.User;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Password { get; }

    public string Email { get; }

    public User(string firstName, string lastName, string password, string email)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
    }
}
