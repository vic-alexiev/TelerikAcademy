using System.Globalization;

public static class StringExtension
{
    public static string CapitalizeFirstLetters(this string value, CultureInfo culture)
    {
        return culture.TextInfo.ToTitleCase(value);
    }
}
