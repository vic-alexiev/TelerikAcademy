using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindModels;

namespace NorthwindDbContextTests
{
    [TestClass]
    public class NorthwindDbContextTest
    {
        [TestMethod]
        public void TestInsertNewCustomer()
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                DataAccess.Initialize(dbContext);

                DataAccess.InsertNewCustomer(
                    "TELRK",
                    "Telerik Corp.",
                    "Svetozar Georgiev",
                    "Mr.",
                    "33 Alexander Malinov Blvd.",
                    "Sofia",
                    "Sofia",
                    "1729",
                    "Bulgaria",
                    "+359 2 809 98 62",
                    "+359 2 809 98 62");

                Customer customer = DataAccess.GetCustomerByID("TELRK");

                Assert.IsTrue(customer != null);

                Assert.AreEqual("Telerik Corp.", customer.CompanyName);
                Assert.AreEqual("Svetozar Georgiev", customer.ContactName);
                Assert.AreEqual("Mr.", customer.ContactTitle);
                Assert.AreEqual("33 Alexander Malinov Blvd.", customer.Address);
                Assert.AreEqual("Sofia", customer.City);
                Assert.AreEqual("Sofia", customer.Region);
                Assert.AreEqual("1729", customer.PostalCode);
                Assert.AreEqual("Bulgaria", customer.Country);
                Assert.AreEqual("+359 2 809 98 62", customer.Phone);
                Assert.AreEqual("+359 2 809 98 62", customer.Fax);

                DataAccess.UpdateCustomerByID(
                    "TELRK",
                    "Telerik Corp.",
                    "Vassil Terziev",
                    "Mr.",
                    "33 Alexander Malinov Blvd.",
                    "Sofia",
                    "Sofia",
                    "1729",
                    "Bulgaria",
                    "+359 2 809 98 62",
                    "+359 2 809 98 62");

                customer = DataAccess.GetCustomerByID("TELRK");

                Assert.IsTrue(customer != null);

                Assert.AreEqual("Telerik Corp.", customer.CompanyName);
                Assert.AreEqual("Vassil Terziev", customer.ContactName);
                Assert.AreEqual("Mr.", customer.ContactTitle);
                Assert.AreEqual("33 Alexander Malinov Blvd.", customer.Address);
                Assert.AreEqual("Sofia", customer.City);
                Assert.AreEqual("Sofia", customer.Region);
                Assert.AreEqual("1729", customer.PostalCode);
                Assert.AreEqual("Bulgaria", customer.Country);
                Assert.AreEqual("+359 2 809 98 62", customer.Phone);
                Assert.AreEqual("+359 2 809 98 62", customer.Fax);

                DataAccess.RemoveCustomerByID("TELRK");

                customer = DataAccess.GetCustomerByID("TELRK");

                Assert.IsTrue(customer == null);
            }
        }
    }
}
