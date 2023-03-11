using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Teacher;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext context) : base(context)
    {
    }
}
