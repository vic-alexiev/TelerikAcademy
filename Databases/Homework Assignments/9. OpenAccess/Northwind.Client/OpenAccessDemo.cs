using Northwind.Model;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Telerik.OpenAccess;
using System.Collections.Generic;

namespace Northwind.Client
{
    /// <summary>
    /// http://tv.telerik.com/watch/orm/customing-code-generation-templates-in-openaccess-orm
    /// 
    /// http://www.telerik.com/community/forums/orm/general-discussions/how-to-memorize-option-serializable-in-object-class.aspx
    /// </summary>
    internal class OpenAccessDemo
    {
        private static void SerializeDeserialize(string customerId)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = SerializeToBinaryStream(customerId);
            stream.Seek(0, SeekOrigin.Begin);

            Customer customer = formatter.Deserialize(stream) as Customer;

            Console.WriteLine("Country: {0}", customer.Country);
        }

        private static MemoryStream SerializeToBinaryStream(string customerId)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();
            using (EntitiesModel dbContext = new EntitiesModel())
            {
                Customer customer = dbContext.Customers.Where(c => c.CustomerID == customerId).First();
                formatter.Serialize(stream, customer);
            }

            return stream;
        }

        private static void BulkInsert(EntitiesModel context)
        {
            List<Product> products = new List<Product>(50000);

            for (int i = 0; i < 50000; i++)
            {
                Product product = new Product() { ProductName = "Lexus" + i, SupplierID = 5, CategoryID = 5, UnitPrice = 1000m, QuantityPerUnit = "1 piece" };
                products.Add(product);
            }

            context.Add(products);

            context.SaveChanges();
        }

        private static void BulkDelete(EntitiesModel context)
        {
            context.Log = null;

            var query = context.GetAll<Product>().Where(p => p.ProductID % 7 == 1);
            int deleted = query.DeleteAll();

            Console.WriteLine("Deleted products: {0}", deleted);
        }

        private static void SlowDelete(EntitiesModel context)
        {
            context.Delete(context.Products.Where(p => p.ProductID % 7 == 2));
            context.SaveChanges();
        }

        private static void TestOpenAccessDelete()
        {
            var context = new EntitiesModel();

            try
            {
                var products = context.Products.Count();

                Console.WriteLine(products);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
            }

            // Use this to populate your database with 50000 products
            BulkInsert(context);

            //BulkDelete(context);

            //SlowDelete(context);

        }

        private static void Main()
        {
            // Task 1 - see NorthwindFramework project and code generation template DefaultTemplateCS_ver.1.tt
            // (Northwind.Model project, folder Templates)
            // NotificationObject is the common base class 

            // Task 2
            SerializeDeserialize("ALFKI");

            // Task 3
            //BulkInsert(new EntitiesModel());

            //BulkDelete(new EntitiesModel());

            //SlowDelete(new EntitiesModel());
        }
    }
}
