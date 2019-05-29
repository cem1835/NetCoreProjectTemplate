using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Project.Extensions.ObjectExtensions
{
    public static class ObjectExtensions
    {

        public static TConvert ConvertTo<T,TConvert>(this T entity,TConvert convertedObj)
        {
            foreach (var prop in entity.GetType().GetProperties())
            {
                var value = prop.GetValue(entity, null);

                if (value == null)
                    continue;

                var target = convertedObj.GetType().GetProperty(prop.Name);

                if (target != null)
                    if (prop.PropertyType.GenericTypeArguments.Length > 0)
                        target.SetValue(convertedObj, Convert.ChangeType(value, prop.PropertyType.GenericTypeArguments[0], CultureInfo.InvariantCulture));
                    else
                        target.SetValue(convertedObj, Convert.ChangeType(value, prop.PropertyType, CultureInfo.InvariantCulture));
            }
            return convertedObj;
        }

        public static bool IsEnum(Type t)
        {
            if (t.IsEnum) return true;
            return t.IsGenericType &&
                   t.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                   t.GetGenericArguments()[0].IsEnum;
        }
    }
}
