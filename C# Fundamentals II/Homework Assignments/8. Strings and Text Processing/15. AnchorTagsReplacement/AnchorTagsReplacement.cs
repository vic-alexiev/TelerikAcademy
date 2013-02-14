using System;
using System.Text.RegularExpressions;

class AnchorTagsReplacement
{
    private static string ReplaceAnchorTags(string input)
    {
        string anchorPattern = @"<\s*a\s[^>]*?\bhref\s*=\s*" +
@"('(?<url>[^']*)'|""(?<url>[^""]*)""|" +
@"(?<url>\S*))[^>]*>" +
@"(?<linktext>[^<]*)<\s*/a\s*>";

        string result = Regex.Replace(input, anchorPattern,
            delegate(Match m) { return String.Format("[URL={0}]{1}[/URL]", m.Groups["url"].Value, m.Groups["linktext"].Value); });

        return result;
    }

    static void Main()
    {
        string html = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        string outputHtml = ReplaceAnchorTags(html);

        Console.WriteLine(outputHtml);
    }
}
