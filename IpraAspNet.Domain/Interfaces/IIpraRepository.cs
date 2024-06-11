using System.Linq.Expressions;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Specification;


namespace IpraAspNet.Domain.Interfaces;

public interface IIpraRepository: IBaseRepository<Ipra>
{
    TResult GetById<TResult>(Specification<Ipra> spec,Expression<Func<Ipra, TResult>> mapper);
}