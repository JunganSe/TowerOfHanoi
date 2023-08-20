namespace TowerOfHanoi.Core.Extensions;

public static class CommonExtensions
{
    public static string Truncate(this string value, int maxLength)
        => (value.Length <= maxLength) 
            ? value : value[..maxLength];

    public static string PadBoth(this string value, int totalWidth, char paddingChar = ' ')
    {
        if (value.Length >= totalWidth)
            return value;
        string padded = value.PadRight(totalWidth, paddingChar);
        int shift = (totalWidth - value.Length) / 2;
        return padded[^shift..] + padded[..^shift];
    }
}
