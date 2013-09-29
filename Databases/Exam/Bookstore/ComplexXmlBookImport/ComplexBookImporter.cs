using Models;
using System;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Transactions;
using System.Xml.XPath;

namespace ComplexXmlBookImport
{
    internal class ComplexBookImporter
    {
        private static void ParseAndSaveBook(BookstoreEntities bookstoreContext, XPathNodeIterator iterator)
        {
            using (var scope = new TransactionScope())
            {
                XPathNavigator currentNode = iterator.Current;

                XPathNavigator bookTitleNode = currentNode.SelectSingleNode("title");
                XPathNavigator bookAuthorsNode = currentNode.SelectSingleNode("authors");
                XPathNavigator bookWebSiteNode = currentNode.SelectSingleNode("web-site");
                XPathNavigator bookReviewsNode = currentNode.SelectSingleNode("reviews");
                XPathNavigator bookIsbnNode = currentNode.SelectSingleNode("isbn");
                XPathNavigator bookPriceNode = currentNode.SelectSingleNode("price");

                string bookTitle = Utils.GetNodeValue(bookTitleNode);
                if (bookTitle == null)
                {
                    throw new XPathException("Book title is a required tag.");
                }

                var book = new Book();
                book.BookTitle = bookTitle;

                if (bookAuthorsNode != null)
                {
                    var authorsIterator = bookAuthorsNode.SelectChildren(XPathNodeType.Element);

                    while (authorsIterator.MoveNext())
                    {
                        XPathNavigator authorNode = authorsIterator.Current;

                        var author = Utils.GetAuthor(bookstoreContext, authorNode);

                        book.Authors.Add(author);
                    }
                }

                string bookWebSite = Utils.GetNodeValue(bookWebSiteNode);
                book.BookWebSite = bookWebSite;

                string bookIsbn = Utils.GetNodeValue(bookIsbnNode);
                book.BookISBN = bookIsbn;

                string bookPriceAsString = Utils.GetNodeValue(bookPriceNode);

                decimal? bookPrice = null;
                if (bookPriceAsString != null)
                {
                    bookPrice = decimal.Parse(bookPriceAsString);
                }

                book.BookPrice = bookPrice;

                bookstoreContext.Books.Add(book);
                bookstoreContext.SaveChanges();

                if (bookReviewsNode != null)
                {
                    var reviewsIterator = bookReviewsNode.SelectChildren(XPathNodeType.Element);

                    while (reviewsIterator.MoveNext())
                    {
                        var bookReview = new BookReview();

                        XPathNavigator reviewNode = reviewsIterator.Current;

                        string reviewContents = Utils.GetNodeValue(reviewNode);
                        bookReview.BookReviewContents = reviewContents;

                        var reviewAuthorNode = reviewNode.SelectSingleNode("@author");
                        if (reviewAuthorNode != null)
                        {
                            var author = Utils.GetAuthor(bookstoreContext, reviewAuthorNode);

                            bookReview.Author = author;
                        }

                        var reviewDateNode = reviewNode.SelectSingleNode("@date");
                        DateTime bookReviewDate = DateTime.Now;

                        if (reviewDateNode != null)
                        {
                            bookReviewDate = Utils.GetDate(reviewDateNode);
                        }

                        bookReview.BookReviewDate = bookReviewDate;
                        bookReview.Book = book;

                        bookstoreContext.BookReviews.Add(bookReview);
                    }

                    bookstoreContext.SaveChanges();
                }

                scope.Complete();
            }
        }

        private static void Main()
        {

            BookstoreEntities bookstoreContext = null;

            try
            {
                XPathDocument doc = new XPathDocument("../../Resources/test-transaction.xml");
                XPathNavigator navigator = doc.CreateNavigator();
                XPathExpression expression = navigator.Compile("/catalog/book");
                XPathNodeIterator iterator = navigator.Select(expression);

                bookstoreContext = new BookstoreEntities();

                while (iterator.MoveNext())
                {
                    ParseAndSaveBook(bookstoreContext, iterator);
                }
            }
            catch (XPathException xpe)
            {
                Console.WriteLine(xpe.Message);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            finally
            {
                if (bookstoreContext != null)
                {
                    bookstoreContext.Dispose();
                }
            }
        }
    }
}
