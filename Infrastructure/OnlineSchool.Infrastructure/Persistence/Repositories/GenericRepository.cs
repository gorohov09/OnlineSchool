using OnlineSchool.App.Common.Interfaces.Persistence;
using System.Linq.Expressions;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    public Task<bool> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}