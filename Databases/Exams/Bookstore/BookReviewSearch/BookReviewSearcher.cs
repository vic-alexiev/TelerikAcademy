using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Data.Entity;

namespace BookReviewSearch
{
    internal class BookReviewSearcher
    {
        private static void ProcessQuery(BookstoreEntities bookstoreContext, XPathNodeIterator iterator, XmlTextWriter writer)
        {
            writer.WriteStartElement("result-set");

            XPathNavigator currentNode = iterator.Current;

            var queryTypeNode = currentNode.SelectSingleNode("@type");
            string queryType = queryTypeNode.Value;

            IOrderedQueryable<BookReview> reviewsFound = null;

            if (queryType == "by-period")
            {
                var startDateNode = currentNode.SelectSingleNode("start-date");
                DateTime startDate = Utils.GetDate(startDateNode);

                var endDateNode = currentNode.SelectSingleNode("end-date");
                DateTime endDate = Utils.GetDate(endDateNode);

                reviewsFound =
                    from bookReview in bookstoreContext.BookReviews.Include(br => br.Book.Authors)
                    where bookReview.BookReviewDate >= startDate && bookReview.BookReviewDate <= endDate
                    orderby bookReview.BookReviewDate, bookReview.BookReviewContents
                    select bookReview;
            }
            else
            {
                var authorNameNode = currentNode.SelectSingleNode("author-name");
                string authorName = authorNameNode.Value;

                reviewsFound =
                    from bookReview in bookstoreContext.BookReviews.Include(br => br.Book.Authors)
                    where string.Compare(bookReview.Author.AuthorName, authorName, true) == 0
                    orderby bookReview.BookReviewDate, bookReview.BookReviewContents
                    select bookReview;
            }

            foreach (var review in reviewsFound)
            {
                InsertReviewData(writer, review);
            }

            writer.WriteEndElement();
        }

        private static void InsertReviewData(XmlTextWriter writer, BookReview review)
        {
            writer.WriteStartElement("review");

            if (review.BookReviewDate != null)
            {
                writer.WriteElementString("date", review.BookReviewDate.Value.ToString("dd-MMM-yyyy"));
            }

            writer.WriteElementString("content", review.BookReviewContents);

            writer.WriteStartElement("book");

            writer.WriteElementString("title", review.Book.BookTitle);

            if (review.Book.Authors.Count > 0)
            {
                var authorNames = review.Book.Authors.Select(a => a.AuthorName).OrderBy(n => n);
                writer.WriteElementString("authors", string.Join(", ", authorNames));
            }

            if (review.Book.BookISBN != null)
            {
                writer.WriteElementString("isbn", review.Book.BookISBN);
            }

            if (review.Book.BookWebSite != null)
            {
                writer.WriteElementString("url", review.Book.BookWebSite);
            }

            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        private static void Main()
        {
            XPathDocument doc = new XPathDocument("../../Resources/performance-test.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            XPathExpression expression = navigator.Compile("/review-queries/query");
            XPathNodeIterator iterator = navigator.Select(expression);

            string resultFileName = "../../Resources/performance-test-results.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(resultFileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                using (var bookstoreContext = new BookstoreEntities())
                {
                    while (iterator.MoveNext())
                    {
                        ProcessQuery(bookstoreContext, iterator, writer);
                    }
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }
    }
}
