using System.Text;

public static class StringBuilderExtension
{
    public static StringBuilder Substring(this StringBuilder value, int startIndex, int length)
    {
        return new StringBuilder(value.ToString(), startIndex, length, value.Capacity);
    }
}
