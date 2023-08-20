namespace TowerOfHanoi.Core.Extensions;

public static class CommonExtensions
{
    public static string Truncate(this string value, int maxLength)
        => (value.Length <= maxLength) 
            ? value : value[..maxLength];

    public static string PadBoth(this string value, int totalWidth, char paddingChar = ' ')
    {
        int totalPaddingSize = totalWidth - value.Length;
        int leftPaddingSize = totalPaddingSize / 2;
        int rightPaddingSize = totalPaddingSize - leftPaddingSize;
        string leftPadding = new string(paddingChar, leftPaddingSize);
        string rightPadding = new string(paddingChar, rightPaddingSize);
        return leftPadding + value + rightPadding;
    }
}
