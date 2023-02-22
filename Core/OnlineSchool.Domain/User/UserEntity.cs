namespace OnlineSchool.Domain.User;

public class UserEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Password { get; }

    public string Email { get; }

    public UserEntity(string firstName, string lastName, string password, string email)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
    }

    public UserEntity()
    {

    }
}
