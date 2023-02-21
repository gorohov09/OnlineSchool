namespace OnlineSchool.Domain.Student;

public class Student
{
    public Guid Id { get; }

    public string LastName { get; }

    public string FirstName { get; }

    public string Patronymic { get; }

    public DateTime BirthDay { get; }

    public string Login { get; }

    public string Password { get; }

    public string GetFullName()
    {
        return $"{LastName} {FirstName} {Patronymic}";
    }
}