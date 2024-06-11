using System.Linq.Expressions;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Specification;

namespace IpraAspNet.Infrastructure.Specification;

public class IpraByIdSpecification(int id): Specification<Ipra>
{
    public override Expression<Func<Ipra, bool>> ToExpression()
    {
        return ipra => ipra.id == id;
    }
}