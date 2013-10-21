using Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Xml;

namespace SimpleBookSearch
{
    internal class SimpleBookSearcher
    {
        private static void Main()
        {
            string bookTitle = null;
            string bookAuthor = null;
            string bookIsbn = null;

            using (XmlTextReader reader = new XmlTextReader("../../Resources/test1.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "title":
                                {
                                    bookTitle = reader.ReadElementString();
                                    break;
                                }
                            case "author":
                                {
                                    bookAuthor = reader.ReadElementString();
                                    break;
                                }
                            case "isbn":
                                {
                                    bookIsbn = reader.ReadElementString();
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }

            using (var bookstoreContext = new BookstoreEntities())
            {
                var booksList =
                    (from book in bookstoreContext.Books.Include(b => b.Authors)
                     where (bookTitle == null || string.Compare(book.BookTitle, bookTitle, true) == 0) &&
                     (bookAuthor == null || book.Authors.Any(a => string.Compare(a.AuthorName, bookAuthor, true) == 0)) &&
                     (bookIsbn == null || string.Compare(book.BookISBN, bookIsbn, true) == 0)
                     orderby book.BookTitle
                     select new
                     {
                         BookTitle = book.BookTitle,
                         ReviewsCount = book.BookReviews.Count()
                     }).ToList();

                int booksFound = booksList.Count;

                if (booksFound == 0)
                {
                    Console.WriteLine("Nothing found");
                }
                else
                {
                    Console.WriteLine("{0} book(s) found:", booksFound);

                    foreach (var book in booksList)
                    {
                        Console.WriteLine(
                            "{0} --> {1} reviews",
                            book.BookTitle,
                            book.ReviewsCount > 0 ? book.ReviewsCount.ToString() : "no");
                    }
                }
            }
        }
    }
}
