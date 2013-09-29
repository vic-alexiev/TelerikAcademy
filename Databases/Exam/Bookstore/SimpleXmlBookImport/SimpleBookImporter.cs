using Models;
using System;
using System.Data.Entity.Validation;
using System.Transactions;
using System.Xml.XPath;

namespace SimpleXmlBookImport
{
    internal class SimpleBookImporter
    {
        private static void ParseAndSaveBook(BookstoreEntities bookstoreContext, XPathNodeIterator iterator)
        {
            using (var scope = new TransactionScope())
            {
                XPathNavigator currentNode = iterator.Current;

                XPathNavigator bookAuthorNode = currentNode.SelectSingleNode("author");
                XPathNavigator bookTitleNode = currentNode.SelectSingleNode("title");
                XPathNavigator bookIsbnNode = currentNode.SelectSingleNode("isbn");
                XPathNavigator bookPriceNode = currentNode.SelectSingleNode("price");
                XPathNavigator bookWebSiteNode = currentNode.SelectSingleNode("web-site");

                string authorName = Utils.GetNodeValue(bookAuthorNode);
                if (authorName == null)
                {
                    throw new XPathException("Book author is a required tag.");
                }

                string bookIsbn = Utils.GetNodeValue(bookIsbnNode);
                string bookTitle = Utils.GetNodeValue(bookTitleNode);
                if (bookTitle == null)
                {
                    throw new XPathException("Book title is a required tag.");
                }

                string bookPriceAsString = Utils.GetNodeValue(bookPriceNode);

                decimal? bookPrice = null;
                if (bookPriceAsString != null)
                {
                    bookPrice = decimal.Parse(bookPriceAsString);
                }

                string bookWebSite = Utils.GetNodeValue(bookWebSiteNode);

                var author = Utils.GetAuthor(bookstoreContext, bookAuthorNode);

                var book = new Book
                {
                    BookTitle = bookTitle,
                    BookISBN = bookIsbn,
                    BookPrice = bookPrice,
                    BookWebSite = bookWebSite
                };

                book.Authors.Add(author);
                bookstoreContext.Books.Add(book);

                bookstoreContext.SaveChanges();
                scope.Complete();
            }
        }

        private static void Main()
        {
            // The Bookstore.sql script is in the \Resources folder of the Models project.

            BookstoreEntities bookstoreContext = null;

            try
            {
                XPathDocument doc = new XPathDocument("../../Resources/test5.xml");
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
