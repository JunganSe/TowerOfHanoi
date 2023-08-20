﻿namespace TowerOfHanoi.Core.Extensions;

public static class CommonExtensions
{
    public static string Truncate(this string value, int maxLength)
        => (value.Length <= maxLength) 
            ? value : value[..maxLength];
}
