using System.Linq.Expressions;

namespace IpraAspNet.Domain.Specification.Extension;

/// <summary>
/// Создает выражение для проверки равенства свойства типа T указанному значению.
/// </summary>
/// <param name="propertyName">Имя свойства для сравнения.</param>
/// <param name="value">Значение, с которым сравнивается свойство.</param>
/// <typeparam name="T">Тип объекта, содержащего свойство.</typeparam>
public class EqualFieldExtension<T>(string? propertyName, string? value): Specification<T>
{
    /// <returns>Выражение для проверки равенства свойства типа T указанному значению.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public override Expression<Func<T, bool>> ToExpression()
    {
        // Создать параметрное выражение, представляющее входной объект типа T
        ParameterExpression parameter = Expression.Parameter(typeof(T));

        // Создать выражение доступа к указанному свойству входного объекта
        try
        {
            if (propertyName != null)
            {
                MemberExpression member = Expression.PropertyOrField(parameter, propertyName);
        
                // Создать константное выражение, представляющее указанное значение
                ConstantExpression constant = Expression.Constant(value);
        
                // Создать бинарное выражение для сравнения на равенство между свойством и значением
                BinaryExpression expression = Expression.Equal(member, constant);
        
                // Создать и вернуть лямбда-выражение, представляющее сравнение на равенство
                return Expression.Lambda<Func<T, bool>>(expression, parameter);
            }
        }
        catch (ArgumentException e)
        {
            throw new ArgumentOutOfRangeException($"Не найдено поле с именем {propertyName}");
        }

        return x => true;
    }
}