using EntityFrameworkModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PDFReportGeneration
{
    public static class PDFConverter
    {
        private const float FontSize = 10f;

        public static void GeneratePDFAggregatedSalesReport()
        {
            string executionFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string salesReportFile = Path.Combine(executionFolder, "Sales-Report.pdf");

            var fs = new FileStream(salesReportFile, FileMode.Create);

            var document = new Document(PageSize.A4, 25, 25, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            var table = new PdfPTable(5);

            table.TotalWidth = 545f;
            table.LockedWidth = true;

            float[] widths = new float[] { 0.75f, 0.5f, 0.25f, 1.25f, 0.25f };
            table.SetWidths(widths);

            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            var cellTitle = new PdfPCell(new Phrase("Aggregated Sales Report", new Font(Font.HELVETICA, FontSize, Font.BOLD)))
            {
                Colspan = 5,
                HorizontalAlignment = 1
            };

            cellTitle.PaddingBottom = 10f;
            cellTitle.PaddingLeft = 10f;
            cellTitle.PaddingTop = 4f;
            table.AddCell(cellTitle);

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
                    DateTime reportDate = DateTime.Now;
                    bool first = true;

                    foreach (var sale in report.Sales)
                    {
                        if (first)
                        {
                            reportDate = sale.SaleDate;
                            WriteTableHeader(table, reportDate);
                            first = false;
                        }

                        var cellProduct = new PdfPCell(new Phrase(sale.ProductName, new Font(Font.HELVETICA, FontSize, Font.NORMAL)));
                        cellProduct.PaddingBottom = 10f;
                        cellProduct.PaddingLeft = 10f;
                        cellProduct.PaddingTop = 4f;
                        table.AddCell(cellProduct);

                        var cellQuantity = new PdfPCell(new Phrase(sale.ProductQuantity.ToString() + " " + sale.Units, new Font(Font.HELVETICA, FontSize, Font.NORMAL)));
                        cellQuantity.PaddingBottom = 10f;
                        cellQuantity.PaddingLeft = 10f;
                        cellQuantity.PaddingTop = 4f;
                        table.AddCell(cellQuantity);

                        var cellUnitPrice = new PdfPCell(new Phrase(sale.ProductUnitPrice.ToString("N2"), new Font(Font.HELVETICA, FontSize, Font.NORMAL)));
                        cellUnitPrice.PaddingBottom = 10f;
                        cellUnitPrice.PaddingLeft = 10f;
                        cellUnitPrice.PaddingTop = 4f;
                        table.AddCell(cellUnitPrice);

                        var cellLocation = new PdfPCell(new Phrase(sale.LocalShopName, new Font(Font.HELVETICA, FontSize, Font.NORMAL)));
                        cellLocation.PaddingBottom = 10f;
                        cellLocation.PaddingLeft = 10f;
                        cellLocation.PaddingTop = 4f;
                        table.AddCell(cellLocation);

                        var cellSum = new PdfPCell(new Phrase(sale.TotalSum.ToString("N2"), new Font(Font.HELVETICA, FontSize, Font.NORMAL)));
                        cellSum.PaddingBottom = 10f;
                        cellSum.PaddingLeft = 10f;
                        cellSum.PaddingTop = 4f;
                        table.AddCell(cellSum);

                    }

                    var cellReportTotalSum = new PdfPCell(new Phrase("Total sum for " + reportDate.ToString("dd-MMM-yyyy") + ":", new Font(Font.HELVETICA, FontSize, Font.NORMAL)))
                    {
                        Colspan = 4,
                        HorizontalAlignment = 2
                    };

                    cellReportTotalSum.PaddingBottom = 10f;
                    cellReportTotalSum.PaddingLeft = 10f;
                    cellReportTotalSum.PaddingTop = 4f;
                    table.AddCell(cellReportTotalSum);

                    var cellTotalSum = new PdfPCell(new Phrase(report.SalesTotalSum.ToString("N2"), new Font(Font.HELVETICA, FontSize, Font.BOLD)));
                    cellTotalSum.PaddingBottom = 10f;
                    cellTotalSum.PaddingLeft = 10f;
                    cellTotalSum.PaddingTop = 4f;
                    table.AddCell(cellTotalSum);
                }

                document.Add(table);

                // Close the document
                document.Close();

                // Close the writer instance
                writer.Close();

                // Always close open filehandles explicity
                fs.Close();
            }
        }

        private static void WriteTableHeader(PdfPTable table, DateTime reportDate)
        {
            var cellDate = new PdfPCell(new Phrase("Date: " + reportDate.ToString("dd-MMM-yyyy"), new Font(Font.HELVETICA, FontSize, Font.NORMAL)))
            {
                Colspan = 5,
                HorizontalAlignment = 0
            };

            cellDate.BackgroundColor = new Color(217, 217, 217);
            cellDate.PaddingBottom = 10f;
            cellDate.PaddingLeft = 10f;
            cellDate.PaddingTop = 4f;
            table.AddCell(cellDate);

            var cellProduct = new PdfPCell(new Phrase("Product", new Font(Font.HELVETICA, FontSize, Font.BOLD)));
            cellProduct.BackgroundColor = new Color(217, 217, 217);
            cellProduct.PaddingBottom = 10f;
            cellProduct.PaddingLeft = 10f;
            cellProduct.PaddingTop = 4f;
            table.AddCell(cellProduct);

            var cellQuantity = new PdfPCell(new Phrase("Quantity", new Font(Font.HELVETICA, FontSize, Font.BOLD)));
            cellQuantity.BackgroundColor = new Color(217, 217, 217);
            cellQuantity.PaddingBottom = 10f;
            cellQuantity.PaddingLeft = 10f;
            cellQuantity.PaddingTop = 4f;
            table.AddCell(cellQuantity);

            var cellUnitPrice = new PdfPCell(new Phrase("Unit Price", new Font(Font.HELVETICA, FontSize, Font.BOLD)));
            cellUnitPrice.BackgroundColor = new Color(217, 217, 217);
            cellUnitPrice.PaddingBottom = 10f;
            cellUnitPrice.PaddingLeft = 10f;
            cellUnitPrice.PaddingTop = 4f;
            table.AddCell(cellUnitPrice);

            var cellLocation = new PdfPCell(new Phrase("Location", new Font(Font.HELVETICA, FontSize, Font.BOLD)));
            cellLocation.BackgroundColor = new Color(217, 217, 217);
            cellLocation.PaddingBottom = 10f;
            cellLocation.PaddingLeft = 10f;
            cellLocation.PaddingTop = 4f;
            table.AddCell(cellLocation);

            var cellSum = new PdfPCell(new Phrase("Sum", new Font(Font.HELVETICA, FontSize, Font.BOLD)));
            cellSum.BackgroundColor = new Color(217, 217, 217);
            cellSum.PaddingBottom = 10f;
            cellSum.PaddingLeft = 10f;
            cellSum.PaddingTop = 4f;
            table.AddCell(cellSum);
        }
    }
}
