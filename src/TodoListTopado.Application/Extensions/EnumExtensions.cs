using System;
using System.Reflection;
using TodoListTopado.Application.Dtos.TaskItem.Request;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var fieldInfo = type.GetField(value.ToString());

        var attribute = fieldInfo
            .GetCustomAttribute<ErrorDescriptionAttribute>();

        return attribute == null ? value.ToString() : attribute.Description;
    }
}
