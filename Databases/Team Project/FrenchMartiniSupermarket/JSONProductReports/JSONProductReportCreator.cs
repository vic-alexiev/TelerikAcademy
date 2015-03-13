using EntityFrameworkModels;
using JSONProductReports;
using MongoDataModels;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace JSONProductsReports
{
    public static class JSONProductReportCreator
    {
        public static void GenerateProductReports(string folderName)
        {
            DirectoryInfo directory = Directory.CreateDirectory(folderName);

            List<MongoProductReport> mongoProductsReports = new List<MongoProductReport>();
            MongoDBManager<MongoProductReport> mongo = new MongoDBManager<MongoProductReport>();

            using (var msSQLServerContext = new SupermarketEntities())
            {
                var sales =
                    from product in msSQLServerContext.Products
                    join vendor in msSQLServerContext.Vendors
                    on product.VendorId equals vendor.VendorId
                    join sale in msSQLServerContext.Sales
                    on product.ProductId equals sale.ProductId
                    group sale by sale.ProductId into productsById
                    select new
                    {
                        ProductId = productsById.Key,
                        SalesTotalQuantity = productsById.Sum(s => s.ProductQuantity),
                        SalesTotalSum = productsById.Sum(s => s.ProductTotalSum)
                    };

                var productReports =
                    from sale in sales
                    join product in msSQLServerContext.Products
                    on sale.ProductId equals product.ProductId
                    join vendor in msSQLServerContext.Vendors
                    on product.VendorId equals vendor.VendorId
                    select new
                    {
                        ProductId = sale.ProductId,
                        ProductName = product.ProductName,
                        VendorName = vendor.VendorName,
                        SalesTotalQuantity = sale.SalesTotalQuantity,
                        SalesTotalSum = sale.SalesTotalSum
                    };

                foreach (var productReport in productReports)
                {
                    JObject jsonObject = new JObject(
                        new JProperty("product-id", productReport.ProductId),
                        new JProperty("product-name", productReport.ProductName),
                        new JProperty("vendor-name", productReport.VendorName),
                        new JProperty("total-quantity-sold", productReport.SalesTotalQuantity),
                        new JProperty("total-incomes", productReport.SalesTotalSum));

                    string filePath = Path.Combine(folderName, string.Format("{0}.json", productReport.ProductId));

                    using (FileStream file = File.Create(filePath))
                    {
                        using (StreamWriter writer = new StreamWriter(file))
                        {
                            writer.Write(jsonObject.ToString());
                        }
                    }

                    MongoProductReport mongoProductReport = new MongoProductReport
                    {
                        ProductId = productReport.ProductId,
                        ProductName = productReport.ProductName,
                        VendorName = productReport.VendorName,
                        TotalQuantitySold = productReport.SalesTotalQuantity,
                        TotalIncomes = productReport.SalesTotalSum
                    };

                    mongoProductsReports.Add(mongoProductReport);
                }
            }

            mongo.InsertInMongoDB(mongoProductsReports, "ProductsReports");
        }
    }
}