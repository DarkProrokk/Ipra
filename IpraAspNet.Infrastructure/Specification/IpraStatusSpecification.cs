using System.Linq.Expressions;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Enums;
using IpraAspNet.Domain.Specification;

namespace IpraAspNet.Infrastructure.Specification;

public class IpraStatusSpecification(IpraFilterByStatus status): Specification<Ipra>
{
    public override Expression<Func<Ipra, bool>> ToExpression()
    {
        switch (status)
        {
            case IpraFilterByStatus.NoFilter:
                return ipra => true;
            case IpraFilterByStatus.ByOpen:
                return ipra => ipra.StatusId == 1;
            case IpraFilterByStatus.ByWork:
                return ipra => ipra.Reports != null && ipra.StatusId == 1 && ipra.Reports.Count > 0;
            case IpraFilterByStatus.BySpent:
                return ipra => ipra.StatusId == 2;
            case IpraFilterByStatus.ByClose:
                int[] closedId = { 3, 4, 5 };
                return ipra => closedId.Contains(ipra.StatusId);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}