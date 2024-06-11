using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Specification;
using System.Linq.Expressions;
using IpraAspNet.Domain.QueryObjects;
using IpraAspNet.Domain.QueryObjects.Interfaces;

namespace IpraAspNet.Domain.Interfaces;

public interface IBaseRepository<T> where T: class
{

    IEnumerable<TResult> GetAll<TEntity, TResult>(ISpecification<TEntity> spec,
        Expression<Func<TEntity, TResult>> mapper, IPagingOptions options) where TEntity : class;

    ValueTask<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task Delete(int id);
    
    void Save();

    Task SaveAsync();
}