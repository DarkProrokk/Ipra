using System.Linq.Expressions;

namespace IpraAspNet.Domain.Specification;

public abstract class Specification<T>: ISpecification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();
}