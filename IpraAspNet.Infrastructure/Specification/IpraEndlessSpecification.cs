using System.Linq.Expressions;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Enums;
using IpraAspNet.Domain.Specification;

namespace IpraAspNet.Infrastructure.Specification;

public class IpraEndlessSpecification(IpraFilterByEndless endless): Specification<Ipra>
{
    public override Expression<Func<Ipra, bool>> ToExpression()
    {
        switch (endless)
        {
            case IpraFilterByEndless.NoFilter:
                return ipra => true;
            case IpraFilterByEndless.Expiring:
                return ipra => true;
            case IpraFilterByEndless.WithEndDate:
                return ipra => !ipra.IsEndless;
            case IpraFilterByEndless.Indefinitely:
                return ipra => ipra.IsEndless;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}