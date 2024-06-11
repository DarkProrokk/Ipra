using System.Linq.Expressions;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Interfaces;
using IpraAspNet.Domain.Specification;
using IpraAspNet.Application.Context;
using IpraAspNet.Application.Dtos;
using IpraAspNet.Infrastructure.Repositories;

namespace IpraAspNet.Application.Repositories;

public class IpraRepository(IpraContext context): BaseRepository<Ipra>(context, context.Ipras), IIpraRepository
{
    private readonly IpraContext _context = context;

    
    

    public TResult? GetById<TResult>(Specification<Ipra> spec,Expression<Func<Ipra,TResult>> mapper)
    {
        var result = _context.Set<Ipra>().Where(spec.ToExpression()).Select(mapper).FirstOrDefault();
        return result;
    }
}