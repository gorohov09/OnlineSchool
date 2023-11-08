using OnlineSchool.App.Common.Interfaces.Services;

namespace OnlineSchool.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

    public DateTime TimeNow => DateTime.Now;
}
