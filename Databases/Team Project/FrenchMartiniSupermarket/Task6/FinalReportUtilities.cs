using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModels;
using MongoDB.Driver;
using MongoDataModels;
using MongoDB.Driver.Linq;
using VendorFinalReport;

namespace VendorFinalReport
{
    public static class FinalReportUtilities
    {
        private static string vendorCollectionString = "vendorCollection";
        private static string productColelctionString = "productsCollection";

        private static void Main()
        {
            //InsertDataMonogDB();
            //InsertSQLiteData();
            PrintMongoDB();
            PrintSQlDB();

            var list = QueryIt();

            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }

        public static List<VendorData> QueryIt()
        {
            TaxesEntities context = new TaxesEntities();

            var connectionStr = "mongodb://localhost";
            var client = new MongoClient(connectionStr);
            var server = client.GetServer();
            var db = server.GetDatabase("supermarketExtra");

            var dbExpenses = db.GetCollection<MongoVendorExpense>(vendorCollectionString);

            var prodReport = db.GetCollection<MongoProductReport>(productColelctionString);

            List<VendorData> list = new List<VendorData>();

            int month = 3;
            int year = 1998;

            var vendorsMongo =
                              from p in dbExpenses.AsQueryable<MongoVendorExpense>()
                              where p.Month == month && p.Year == year
                              select p;
         
            foreach (var vendor in vendorsMongo)
            {
                decimal totalIncome = 0;
                decimal totalTaxes = 0;
                decimal Expenses = vendor.Amount;
                decimal result = 0;

                var products = from p in prodReport.AsQueryable<MongoProductReport>()
                               where p.VendorName == vendor.VendorName
                               select p;

                foreach (var product in products)
                {
                    var res = from p in context.Taxes
                              where p.ProductName == product.ProductName
                              select p;
                    decimal taxSize = Convert.ToDecimal(res.FirstOrDefault().TaxSize);

                    decimal productTax = product.TotalIncomes * 0.01M * taxSize;

                    totalTaxes += productTax;
                    totalIncome += product.TotalIncomes - productTax;
                }

                result = totalIncome - totalTaxes - Expenses;

                list.Add(new VendorData(vendor.VendorName, totalIncome, totalTaxes, Expenses, result));
            }

            return list;
        }

        public static void InsertDataMonogDB()
        {
            var connectionStr = "mongodb://localhost";
            var client = new MongoClient(connectionStr);
            var server = client.GetServer();
            var db = server.GetDatabase("supermarketExtra");

            //Insert Vendor
            var expenses = db.GetCollection<MongoVendorExpense>(vendorCollectionString);
            var obj = new MongoVendorExpense() { VendorName = "Svoge", Month = 3, Year = 1998, Amount = 200 };
            expenses.Insert<MongoVendorExpense>(obj);

            //Insert products reports
            var prodReport = db.GetCollection<MongoProductReport>(productColelctionString);
            var bira1 = new MongoProductReport()
            {
                ProductId = 3,
                ProductName = "Zagorka",
                VendorName = "Svoge",
                TotalIncomes = 234,
                TotalQuantitySold = 14
            };

            var bira2 = new MongoProductReport()
            {
                ProductId = 2,
                ProductName = "Kamenitza",
                VendorName = "Svoge",
                TotalIncomes = 334,
                TotalQuantitySold = 14
            };

            var bira3 = new MongoProductReport()
            {
                ProductId = 1,
                ProductName = "Amstel",
                VendorName = "Svoge",
                TotalIncomes = 14,
                TotalQuantitySold = 14
            };

            var bira4 = new MongoProductReport()
            {
                ProductId = 5,
                ProductName = "Korola",
                VendorName = "Svoge",
                TotalIncomes = 2234,
                TotalQuantitySold = 14
            };

            prodReport.Insert<MongoProductReport>(bira1);
            prodReport.Insert<MongoProductReport>(bira2);
            prodReport.Insert<MongoProductReport>(bira3);
            prodReport.Insert<MongoProductReport>(bira4);
        }

        public static void PrintMongoDB()
        {
            var connectionStr = "mongodb://localhost";
            var client = new MongoClient(connectionStr);
            var server = client.GetServer();
            var db = server.GetDatabase("supermarketExtra");

            //Print Vendor
            var expenses = db.GetCollection<MongoVendorExpense>(vendorCollectionString);
            var vendorsMongo =
                              from p in expenses.AsQueryable<MongoVendorExpense>()
                              select p;

            Console.WriteLine("--------------Vendor expenses:");
            foreach (var f in vendorsMongo)
            {
                Console.WriteLine(f);
            }

            //Print Products Reports
            var prodReport = db.GetCollection<MongoProductReport>(productColelctionString);
            var productsMongo =
                               from p in prodReport.AsQueryable<MongoProductReport>()
                               select p;

            Console.WriteLine("-------------Products reports:");
            foreach (var f in productsMongo)
            {
                Console.WriteLine(f);
            }
        }

        public static void InsertSQLiteData()
        {
            TaxesEntities context = new TaxesEntities();

            context.Taxes.Add(new Tax() { ProductName = "Zagorka", TaxSize = 20 });
            context.Taxes.Add(new Tax() { ProductName = "Kamenitza", TaxSize = 20 });
            context.Taxes.Add(new Tax() { ProductName = "Amstel", TaxSize = 10 });
            context.Taxes.Add(new Tax() { ProductName = "Korola", TaxSize = 20 });

            context.SaveChanges();
        }

        private static void PrintSQlDB()
        {
            TaxesEntities context = new TaxesEntities();

            var query =
                       from p in context.Taxes
                       select p;

            Console.WriteLine("SQL DB:");
            foreach (var data in query)
            {
                Console.WriteLine(data.ProductName + " has tax: " + data.TaxSize + "%");
            }
        }
    }
}
