﻿using System.Linq.Expressions;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IGenericRepository<T>
    where T : class
{
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
