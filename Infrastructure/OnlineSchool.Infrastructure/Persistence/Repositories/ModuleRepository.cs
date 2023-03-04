using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class ModuleRepository : GenericRepository<ModuleEntity>, IModuleRepository
{
    public ModuleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<ModuleEntity?> FindModuleByIdWithLessons(Guid moduleId)
    {
        return await _context.Modules
            .Include(module => module.Lessons)
            .FirstOrDefaultAsync(module => module.Id == moduleId);
    }
}
