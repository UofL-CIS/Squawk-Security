using System;
using System.Text;

namespace Squawk_Security.ClassLibrary.Extensions
{
    public static class Extensions
    {
        public static string PrintPropertiesAsString(this object obj)
        {
            var sb = new StringBuilder();
            var type = obj.GetType();

            var properties = type.GetProperties();
            var fields = type.GetFields();

            foreach (var propertyInfo in properties)
            {
                sb.Append($"{propertyInfo.Name}: {propertyInfo.GetValue(obj)}{Environment.NewLine}");
            }

            foreach (var fieldInfo in fields)
            {
                sb.Append($"{fieldInfo.Name}: {fieldInfo.GetValue(obj)}{Environment.NewLine}");
            }

            return sb.ToString();
        }
    }
}
