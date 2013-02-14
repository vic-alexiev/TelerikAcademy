using System;
using System.Text.RegularExpressions;

class ExtractUrlData
{
    private struct UrlData
    {
        public string Protocol { get; set; }
        public string Server { get; set; }
        public string Resource { get; set; }
    }

    private static UrlData GetUrlData(string url)
    {
        string pattern = @"^((?<protocol>[a-z]+)://)?(?<server>[\w\.\-]+)(?<resource>[\w\.#=&\+\-%\/\?]+)?$";

        Match match = Regex.Match(url, pattern);

        if (match.Success)
        {
            return new UrlData
            {
                Protocol = match.Groups["protocol"].Value,
                Server = match.Groups["server"].Value,
                Resource = match.Groups["resource"].Value
            };
        }
        else
        {
            return new UrlData
            {
                Protocol = String.Empty,
                Server = String.Empty,
                Resource = String.Empty
            };
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.Write("Enter a valid URL: ");
            string url = Console.ReadLine();

            UrlData urlData = GetUrlData(url);

            Console.WriteLine("Protocol: {0}\nServer: {1}\nResource: {2}\n",
                urlData.Protocol, urlData.Server, urlData.Resource); 
        }
    }
}
