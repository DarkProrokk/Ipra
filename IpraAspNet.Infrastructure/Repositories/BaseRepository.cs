using System.Linq.Expressions;
using IpraAspNet.Application.Context;
using IpraAspNet.Domain.Interfaces;
using IpraAspNet.Domain.QueryObjects.Interfaces;
using IpraAspNet.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using static IpraAspNet.Infrastructure.Specification.PagingSpecification;

namespace IpraAspNet.Infrastructure.Repositories;

public class BaseRepository<TEntity>(IpraContext context, DbSet<TEntity> dbSet)
    : IBaseRepository<TEntity> where TEntity : class
{
    public virtual IEnumerable<TEntity> GetAll()
    {
        return dbSet;
    }

    public IEnumerable<TResult> GetAll<T, TResult>(ISpecification<T> spec,
        Expression<Func<T, TResult>> mapper, IPagingOptions options) where T : class
    {
        var data = context.Set<T>()
            .Where(spec.ToExpression()).Select(mapper);
        return data.ApplyPaging(pageNum: options.PageNum, pageSize: options.PageSize);
    }

    public ValueTask<TEntity?> GetByIdAsync(int id)
    {
        return dbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public void Update(TEntity entity)
    {
        dbSet.Update(entity);
        Save();
    }

    public void Delete(TEntity entity)
    {
        dbSet.Remove(entity);
        Save();
    }

    public async Task Delete(int id)
    {
        TEntity? entity = await GetByIdAsync(id);
        if (entity is not null)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Save()
    {
        context.SaveChanges();
    }
}