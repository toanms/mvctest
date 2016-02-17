using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Ca.Skoolbo.Homesite.Helpers
{
    public static class EnumHelper
    {
        public static string ConvertValueToDisplayName<T>(this string value) where T : struct
        {
            return value.ConvertValueToEnum<T>().GetEnumDisplayName();
        }
        public static T ConvertValueToEnum<T>(this string value) where T : struct
        {
            T t;
            var isResult = Enum.TryParse(value, true, out t);
            return isResult ? t : default(T);
        }

        public static string ConvertEnumKeyToString<T>(this T value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string GetEnumDisplayName<T>(this T value)
        {
            var type = typeof(T);
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            var description = ((DisplayAttribute)attributes[0]).Name;
            return description;
        }

        public static IEnumerable<T> ConvertListStringToListEnum<T>(List<string> listEnumString) where T : struct
        {
            var listT = new List<T>();

            listEnumString.ForEach(itemRole =>
            {
                var t = itemRole.ConvertValueToEnum<T>();
                listT.Add(t);
            });

            return listT;
        }

        public static TV GetAttributeValue<T, TV>(this Enum enumeration, Func<T, TV> expression)
      where T : Attribute
        {
            var firstOrDefault = enumeration
                .GetType()
                .GetMember(enumeration.ToString()).FirstOrDefault(member => member.MemberType == MemberTypes.Field);
            if (firstOrDefault == null)
                return default(TV);
            T attribute = firstOrDefault
                    .GetCustomAttributes(typeof(T), false)
                    .Cast<T>()
                    .SingleOrDefault();

            if (attribute == null)
                return default(TV);

            return expression(attribute);
        }
    }
}