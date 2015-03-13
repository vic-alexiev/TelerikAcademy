using System;
using System.Linq;
using System.Text;
using System.Xml;
using EntityFrameworkModels;

namespace XmlLib
{
    /// <summary>
    /// Base class for XML based reports for supormarket DB
    /// </summary>
    public static class Reporter
    {
        public static void CreateSalesReport()
        {
            SupermarketEntities supermarkets = new SupermarketEntities();

            var queryResult =
                from vendor in supermarkets.Vendors
                select new
                {
                    Vendor = vendor.VendorName,

                    dayToDayReprots =
                        from sale in supermarkets.Sales
                        join product in supermarkets.Products
                        on sale.ProductId equals product.ProductId
                        join report in supermarkets.Reports
                        on sale.ReportId equals report.ReportId
                        where product.VendorId == vendor.VendorId
                        group sale by report.ReportDate
                            into reportForDate
                            select new
                            {
                                Date = reportForDate.Key,
                                TotalSum = reportForDate.Sum(p => p.ProductTotalSum)
                            }
                };

            string fileName = "../../report.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (var vendor in queryResult)
                {
                    Console.WriteLine("Writing report for " + vendor.Vendor);

                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", vendor.Vendor);

                    foreach (var dayReport in vendor.dayToDayReprots)
                    {
                        writer.WriteStartElement("summary");
                        string dateString = string.Format("{0:dd-MMM-yyyy}", dayReport.Date);
                        writer.WriteAttributeString("date", dateString);
                        writer.WriteAttributeString("total-sum", dayReport.TotalSum.ToString("N2"));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                     
                }

                writer.WriteEndDocument();
            }
        }
    }
}
