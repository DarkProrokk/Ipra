using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Extensions
{
    public static class EqualFieldExtension
    {
        /// <summary>
        /// Создает выражение для проверки равенства свойства типа T указанному значению.
        /// </summary>
        /// <param name="propertyName">Имя свойства для сравнения.</param>
        /// <param name="value">Значение, с которым сравнивается свойство.</param>
        /// <typeparam name="T">Тип объекта, содержащего свойство.</typeparam>
        /// <returns>Выражение, представляющее сравнение на равенство.</returns>
        public static Expression<Func<T, bool>> EqualField<T>(string propertyName, object value)
        {
            // Создать параметрное выражение, представляющее входной объект типа T
            ParameterExpression parameter = Expression.Parameter(typeof(T));

            // Создать выражение доступа к указанному свойству входного объекта
            MemberExpression member = Expression.PropertyOrField(parameter, propertyName);

            // Создать константное выражение, представляющее указанное значение
            ConstantExpression constant = Expression.Constant(value);

            // Создать бинарное выражение для сравнения на равенство между свойством и значением
            BinaryExpression expression = Expression.Equal(member, constant);

            // Создать и вернуть лямбда-выражение, представляющее сравнение на равенство
            return Expression.Lambda<Func<T, bool>>(expression, parameter);
        }
    }
}
