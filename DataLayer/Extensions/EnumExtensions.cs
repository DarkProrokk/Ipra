using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var memberInfo = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        if (memberInfo != null)
        {
            var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null)
            {
                return displayAttribute.GetName();
            }
        }

        return value.ToString(); // Возвращаем значение enum, если атрибут Display не найден
    }
}