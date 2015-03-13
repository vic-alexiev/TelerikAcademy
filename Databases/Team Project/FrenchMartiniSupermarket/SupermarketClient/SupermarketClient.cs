using EntityFrameworkModels;
using ExcelExportFiles;
using OpenAccessModels;
using System;
using System.Linq;

internal class SupermarketClient
{
    /// <summary>
    /// Should be executed only once - when we need  to populate the
    /// MS SQL Server database.
    /// </summary>
    private static void CopyMySQLDataToMSSQLServer()
    {
        using (SupermarketModel mySQLContext = new SupermarketModel())
        {
            using (SupermarketEntities msSQLServerContext = new SupermarketEntities())
            {
                foreach (var mySQLVendor in mySQLContext.Vendors)
                {
                    var msSQLServerVendor = new EntityFrameworkModels.Vendor
                    {
                        VendorName = mySQLVendor.VendorName
                    };

                    msSQLServerContext.Vendors.Add(msSQLServerVendor);
                    msSQLServerContext.SaveChanges();
                }

                foreach (var mySQLUnit in mySQLContext.Units)
                {
                    var msSQLServerUnit = new EntityFrameworkModels.Unit
                    {
                        UnitName = mySQLUnit.UnitName
                    };

                    msSQLServerContext.Units.Add(msSQLServerUnit);
                    msSQLServerContext.SaveChanges();
                }

                foreach (var mySQLProduct in mySQLContext.Products)
                {
                    var msSQLServerProduct = new EntityFrameworkModels.Product
                    {
                        VendorId = mySQLProduct.VendorID,
                        UnitId = mySQLProduct.UnitID,
                        ProductName = mySQLProduct.ProductName,
                        BasePrice = mySQLProduct.BasePrice
                    };

                    msSQLServerContext.Products.Add(msSQLServerProduct);
                    msSQLServerContext.SaveChanges();
                }
            }
        }
    }

    private static void GeneratePDFAggregatedSalesReport()
    {
        using (var msSQLServerContext = new SupermarketEntities())
        {
            var sales =
                from product in msSQLServerContext.Products
                join unit in msSQLServerContext.Units
                on product.UnitId equals unit.UnitId
                join sale in msSQLServerContext.Sales
                on product.ProductId equals sale.ProductId
                join report in msSQLServerContext.Reports
                on sale.ReportId equals report.ReportId
                join localShop in msSQLServerContext.LocalShops
                on report.LocalShopId equals localShop.LocalShopId
                select new
                {
                    ProductName = product.ProductName,
                    ProductQuantity = sale.ProductQuantity,
                    Units = unit.UnitName,
                    ProductUnitPrice = sale.ProductUnitPrice,
                    LocalShopName = localShop.LocalShopName,
                    SaleDate = report.ReportDate,
                    TotalSum = sale.ProductTotalSum
                };

            var reports =
                from sale in sales
                group sale by sale.SaleDate into salesByDate
                select new
                {
                    SalesTotalSum = salesByDate.Sum(s => s.TotalSum),
                    Sales = salesByDate
                };

            foreach (var report in reports)
            {
                foreach (var sale in report.Sales)
                {
                    Console.WriteLine(
                        "{0} {1:N0} {2} {3} {4} {5} {6}",
                        sale.ProductName,
                        sale.ProductQuantity,
                        sale.Units,
                        sale.ProductUnitPrice,
                        sale.LocalShopName,
                        sale.SaleDate,
                        sale.TotalSum);
                }

                Console.WriteLine("--------------------------------" + report.SalesTotalSum);
            }
        }
    }

    private static void Main()
    {
        // Problem #1
        //ExcelManager.LoadExcelReportsFromZipFile(@"F:\Telerik Academy\Databases\Teamwork\Sample-Sales-Reports.zip");

        // Problem #2
        //PDFConverter.GeneratePDFAggregatedSalesReport();

        // Problem #3
        //Reporter.CreateSalesReport(@"F:\code.google.com\FrenchMartiniSupermarket\SupermarketClient\bin\Debug\Sales-by-Vendors-Report.xml");

        // Problem #4
        //JSONProductReportCreator.GenerateProductReports(@"F:\code.google.com\FrenchMartiniSupermarket\SupermarketClient\bin\Debug\Product-Reports");

        //MongoDBManager<MongoVendorExpense> mongoDBManager = new MongoDBManager<MongoVendorExpense>();
        //mongoDBManager.ExportMongoDB("ProductsReports");

        // Problem #5
        //XmlManager.ReadVendorMonthlyExpenses(@"F:\code.google.com\FrenchMartiniSupermarket\SupermarketClient\bin\Debug\VendorsMonthlyReports.xml");
        
        //MongoDBManager<MongoVendorExpense> mongoDBManager = new MongoDBManager<MongoVendorExpense>();
        //mongoDBManager.ExportMongoDB("VendorExpenses");

        // Problem #6
        ExcelManager.GenerateVendorsTotalReportExcel(@"F:\code.google.com\FrenchMartiniSupermarket\SupermarketClient\bin\Debug\Products-Total-Report");
    }
}
