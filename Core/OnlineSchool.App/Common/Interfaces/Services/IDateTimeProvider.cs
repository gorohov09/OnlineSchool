namespace OnlineSchool.App.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
    public DateTime TimeNow { get; }
}
