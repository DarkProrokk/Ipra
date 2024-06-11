using IpraAspNet.Domain.Specification;
using System.Linq.Expressions;


namespace IpraAspNet.Infrastructure.Specification;

public static class PagingSpecification
{
    public static IQueryable<TEntity> ApplyPaging<TEntity>(this IQueryable<TEntity> query, int pageNum = 1, int pageSize = 10)
    {
        var skip = (pageNum - 1) * pageSize;
        return query.Skip(skip).Take(pageSize);
    }
}

