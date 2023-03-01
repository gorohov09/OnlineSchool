using System.Linq.Expressions;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IGenericRepository<T>
    where T : class
{
    Task<IEnumerable<T>> All();
    Task<T> GetById(Guid id);
    Task<bool> Add(T entity);
    Task<bool> Delete(Guid id);
    Task<bool> Update(T entity);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
}
