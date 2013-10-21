using Models;
using System.Xml.XPath;
using System.Linq;
using System;
using System.Globalization;

public static class Utils
{
    public static string GetNodeValue(XPathNavigator node)
    {
        if (node == null)
        {
            return null;
        }

        return node.Value.Trim();
    }

    public static Author GetAuthor(BookstoreEntities bookstoreContext, XPathNavigator node)
    {
        string authorName = Utils.GetNodeValue(node);

        var author = bookstoreContext.Authors.FirstOrDefault(a => a.AuthorName == authorName);

        if (author == null)
        {
            author = new Author
            {
                AuthorName = authorName
            };

            bookstoreContext.Authors.Add(author);
            bookstoreContext.SaveChanges();
        }

        return author;
    }

    public static DateTime GetDate(XPathNavigator node)
    {
        DateTime date = DateTime.Now;

        string dateString = node.Value;

        if (!DateTime.TryParseExact(dateString, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            date = DateTime.ParseExact(dateString, "d-MMM-yyyy", CultureInfo.InvariantCulture);
        }

        return date;
    }
}
