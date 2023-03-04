using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IModuleRepository : IGenericRepository<ModuleEntity>
{
    Task<ModuleEntity?> FindModuleByIdWithLessons(Guid moduleId);
}