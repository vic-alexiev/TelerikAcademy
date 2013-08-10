using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

internal class FeedzillaConsumer
{
    private static async Task<NewsArticleCollection> GetNewsArticles(HttpClient httpClient, string queryString, int count)
    {
        var response = await httpClient.GetAsync(
            string.Format(
            "v1/articles/search.json?q={0}&count={1}",
            queryString,
            count));

        var data = response.Content.ReadAsStringAsync().Result;
        var newsArticleCollection = JsonConvert.DeserializeObject<NewsArticleCollection>(data);

        return newsArticleCollection;
    }

    private static void PrintNewsArticles(NewsArticleCollection newsArticleCollection)
    {
        Console.WriteLine();

        foreach (var article in newsArticleCollection.Articles)
        {
            Console.WriteLine(
                "Title:\r\n{0}\r\nUrl:\r\n{1}\r\n",
                article.Title,
                article.Url);
        }
    }

    private static void Main()
    {
        int count = 10;

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://api.feedzilla.com/");

        Console.WriteLine("Query String: ");
        string queryString = Console.ReadLine();

        var newsArticleCollection = GetNewsArticles(httpClient, queryString, count).Result;
        PrintNewsArticles(newsArticleCollection);
    }
}
