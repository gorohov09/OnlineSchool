namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    IStudentRepository Users { get; }

    Task CompleteAsync();
}
