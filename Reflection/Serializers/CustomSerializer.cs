using System.Globalization;
using System.Text;
using Reflection.Examples;

namespace Reflection.Serializers;

public class CustomSerializer
{
    public static Action<F> Serialize = a =>
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("{");
        var fields = a.GetType().GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            stringBuilder.Append(fields[i].Name + ": " + fields[i].GetValue(a));
            if (i < fields.Length - 1)
            {
                stringBuilder.Append(", ");
            }
        }

        stringBuilder.Append("}");
        stringBuilder.ToString();
    };

    public static Action<string> Deserialize = a =>
    {
        var type = typeof(F);
        var obj = Activator.CreateInstance(type);
        
        var str = a.TrimStart('{').TrimEnd('}');
        foreach (var item in str.Split(","))
        {
            var couple = item.Split(":");
            var fieldName = couple[0].Trim('"');
            var value = couple[1];

            var fieldType = type.GetField(fieldName)?.FieldType;
            object convertedValue = fieldType switch
            {
                Type t when t == typeof(int) => int.Parse(value),
                Type t when t == typeof(long) => long.Parse(value),
                Type t when t == typeof(bool) => bool.Parse(value),
                Type t when t == typeof(double) => double.Parse(value, CultureInfo.InvariantCulture),
                Type t when t == typeof(float) => float.Parse(value, CultureInfo.InvariantCulture),
                Type t when t == typeof(string) => value,
                Type t when t.IsEnum => Enum.Parse(t, value),
                _ => throw new NotSupportedException($"Тип {fieldType} не поддержан")
            };
            type.GetField(fieldName)!.SetValue(obj, convertedValue);
        }
    };
}