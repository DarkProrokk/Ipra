using System.Linq.Expressions;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Specification;

namespace IpraAspNet.Infrastructure.Specification;

public class UserIdNotNullSpecification: Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.UserId != null;
    }
}