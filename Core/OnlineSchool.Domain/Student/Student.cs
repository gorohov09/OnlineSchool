namespace OnlineSchool.Domain.Student;

public class Student
{
    public Guid Id { get; }

    public string LastName { get; }

    public string FirstName { get; }

    public string? Patronymic { get; }

    public DateTime BirthDay { get; }

    public Student(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetFullName()
    {
        return Patronymic is null ? $"{LastName} {FirstName}": $"{LastName} {FirstName} {Patronymic}";
    }
}