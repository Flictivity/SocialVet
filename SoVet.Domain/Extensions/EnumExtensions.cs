﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SoVet.Domain.Extensions;

public static class EnumExtensions
{
    public static string? GetDisplayName(this Enum @enum)
    {
        return @enum.GetType().GetField(@enum.ToString())?.GetCustomAttribute<DisplayAttribute>()?.Name;
    }
}