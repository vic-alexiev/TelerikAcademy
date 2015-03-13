using EntityFrameworkModels;
using JSONProductReports;
using MongoDataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace XmlLib
{
    public static class XmlManager
    {
        /// <summary>
        /// Method for extracting expenses reports in XML format
        /// </summary>
        /// <param name="filePath">Filepath for the .xml file</param>
        public static void ReadVendorMonthlyExpenses(string filePath)
        {
            XmlReader reader = XmlReader.Create(filePath);

            List<MongoVendorExpense> mongoVendorExpensesList = new List<MongoVendorExpense>();

            using (var msSQLServerContext = new SupermarketEntities())
            {
                using (reader)
                {
                    int vendorId = 0;

                    while (reader.Read())
                    {
                        //Insert a new vendor
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "sale")
                        {
                            string vendorName = reader.GetAttribute("vendor");
                            var vendor = msSQLServerContext.Vendors.FirstOrDefault(v => v.VendorName == vendorName);

                            if (vendor == null)
                            {
                                // the vendor doesn't exist
                                vendor = new Vendor
                                {
                                    VendorName = vendorName
                                };

                                msSQLServerContext.Vendors.Add(vendor);
                                msSQLServerContext.SaveChanges();
                            }

                            vendorId = vendor.VendorId;
                        }

                        //Insert Expenses
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "expenses")
                        {
                            string month = reader.GetAttribute("month");
                            DateTime monthAsDate = DateTime.ParseExact(month, "MMM-yyyy", CultureInfo.InvariantCulture);

                            decimal amount = reader.ReadElementContentAsDecimal();

                            var vendorMonthlyExpense = new VendorExpense
                            {
                                VendorId = vendorId,
                                Month = monthAsDate.Month,
                                Year = monthAsDate.Year,
                                Amount = amount
                            };

                            var mongoVendorExpense = new MongoVendorExpense
                            {
                                VendorId = vendorId,
                                Month = monthAsDate.Month,
                                Year = monthAsDate.Year,
                                Amount = amount
                            };

                            mongoVendorExpensesList.Add(mongoVendorExpense);
                            msSQLServerContext.VendorExpenses.Add(vendorMonthlyExpense);
                        }
                    }
                }

                MongoDBManager<MongoVendorExpense> mongoDBInserter = new MongoDBManager<MongoVendorExpense>();
                mongoDBInserter.InsertInMongoDB(mongoVendorExpensesList, "VendorExpenses");

                msSQLServerContext.SaveChanges();
            }
        }
    }
}
