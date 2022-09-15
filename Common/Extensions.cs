using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WcfDebug
{
    public static class Extensions
    {
        public static bool EqualsIgnoreCase(this string value, string other)
        {
            if (value is null)
            {
                return other is null;
            }

            return value.Equals(other, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsFlagEnum(this Type enumType)
        {
            return enumType.IsDefined(typeof(FlagsAttribute));
        }

        public static bool IsFlagEnum<T>(this T value)
            where T : Enum
        {
            var type = value.GetType();
            return type.IsDefined(typeof(FlagsAttribute));
        }

        public static bool Any<T>(this T value, IEnumerable<Enum> flags)
            where T : Enum
        {
            var type = typeof(T);

            if (!type.IsFlagEnum())
            {
                throw new ArgumentException($"Enum {type} must be declared with the {nameof(FlagsAttribute)}.", typeof(T).Name);
            }

            return flags.Any(value.HasFlag);
        }

        public static bool All<T>(this T value, IEnumerable<Enum> flags)
            where T : Enum
        {
            var type = typeof(T);

            if (!type.IsFlagEnum())
            {
                throw new ArgumentException($"Enum {type} must be declared with the {nameof(FlagsAttribute)}.", typeof(T).Name);
            }

            return flags.All(value.HasFlag);
        }
    }
}