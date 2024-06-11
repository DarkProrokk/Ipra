using System.Linq.Expressions;

namespace IpraAspNet.Domain.Specification;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> ToExpression();

}