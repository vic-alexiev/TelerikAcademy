using EntityFrameworkModels;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Transactions;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using VendorFinalReport;

namespace ExcelExportFiles
{
    public static class ExcelManager
    {
        #region Public Methods

        public static System.Data.DataTable GetContents(string filePath)
        {
            System.Data.DataTable contents = new System.Data.DataTable("newtable");

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                filePath +
                ";Extended Properties=Excel 12.0;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string selectSql = @"SELECT * FROM [Sales$B1:E]";

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.Fill(contents);
                }
            }

            return contents;
        }

        public static void LoadExcelReportsFromZipFile(string zipFile)
        {
            string executionFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string salesReportsFolder = Path.Combine(executionFolder, "SalesReports");

            ZipFileManager.Extract(zipFile, salesReportsFolder);

            DirectoryInfo salesReportsDirectory = new DirectoryInfo(salesReportsFolder);

            DirectoryInfo[] reportDirectories = salesReportsDirectory.GetDirectories();

            using (var msSQLServerContext = new SupermarketEntities())
            {
                foreach (DirectoryInfo reportDirectory in reportDirectories)
                {
                    DateTime reportDate = DateTime.ParseExact(
                        reportDirectory.Name,
                        "dd-MMM-yyyy",
                        CultureInfo.InvariantCulture);

                    FileInfo[] reportFiles = reportDirectory.GetFiles("*.xls");

                    foreach (FileInfo reportFile in reportFiles)
                    {
                        System.Data.DataTable contentsTable = ExcelManager.GetContents(reportFile.FullName);

                        InsertExcelFileDataInMSSQLServerDB(reportDate, contentsTable, msSQLServerContext);
                    }
                }
            }
        }

        public static void GenerateVendorsTotalReportExcel(string excelFilePath)
        {
            CreateEmptyVendorsTotalReports2(excelFilePath);
            FillVendorsTotalReportsExcel(excelFilePath, "Sheet1");
        }

        #endregion

        #region Private Methods

        private static void InsertExcelFileDataInMSSQLServerDB(
            DateTime reportDate,
            System.Data.DataTable contentsTable,
            SupermarketEntities msSQLServerContext)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                string localShopName = contentsTable.Rows[0][0].ToString().Trim();

                var localShop = msSQLServerContext.LocalShops.FirstOrDefault(ls => ls.LocalShopName == localShopName);

                if (localShop == null)
                {
                    localShop = new LocalShop
                    {
                        LocalShopName = localShopName
                    };

                    msSQLServerContext.LocalShops.Add(localShop);
                    msSQLServerContext.SaveChanges();
                }

                int rowsCount = contentsTable.Rows.Count;
                int colsCount = contentsTable.Columns.Count;

                var report = new Report
                {
                    LocalShopId = localShop.LocalShopId,
                    ReportDate = reportDate,
                    ReportTotalSum = decimal.Parse(contentsTable.Rows[rowsCount - 1][3].ToString())
                };

                msSQLServerContext.Reports.Add(report);
                msSQLServerContext.SaveChanges();

                for (int row = 2; row < rowsCount - 1; row++)
                {
                    int productId = int.Parse(contentsTable.Rows[row][0].ToString());
                    double productQuantity = double.Parse(contentsTable.Rows[row][1].ToString());
                    decimal productUnitPrice = decimal.Parse(contentsTable.Rows[row][2].ToString());
                    decimal productTotalSum = decimal.Parse(contentsTable.Rows[row][3].ToString());

                    var sale = new Sale
                    {
                        ReportId = report.ReportId,
                        ProductId = productId,
                        ProductQuantity = productQuantity,
                        ProductUnitPrice = productUnitPrice,
                        ProductTotalSum = productTotalSum
                    };

                    msSQLServerContext.Sales.Add(sale);
                }

                msSQLServerContext.SaveChanges();

                scope.Complete();
            }
        }

        private static void CreateEmptyVendorsTotalReports1(string excelFilePath)
        {
            var excelApp = new Application();

            if (excelApp == null)
            {
                Console.WriteLine(
                    "EXCEL could not be started. Check that your office installation and project references are correct.");
                return;
            }

            excelApp.Visible = false;

            Workbook wb = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            var ws = (Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                Console.WriteLine(
                    "Worksheet could not be created. Check that your office installation and project references are correct.");
            }

            const int nCell = 5;

            Range columnsRangeHeader = ws.get_Range("A1", "E1");
            columnsRangeHeader.Interior.Color = ColorTranslator.ToOle(Color.Silver);

            Range columnsRange = ws.get_Range("A1", "E1");
            string[] columns = new string[nCell];

            columns[0] = "Vendor";
            columns[1] = "Incomes";
            columns[2] = "Expenses";
            columns[3] = "Taxes";
            columns[4] = "Financial Result";

            Object[] args2 = new Object[1];
            args2[0] = columns;
            columnsRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, columnsRange, args2);

            wb.SaveAs(excelFilePath, XlFileFormat.xlExcel8);
            wb.ReadOnlyRecommended = false;

            wb.Close();

            excelApp.Quit();
        }

        private static OleDbConnection GetConnection(string excelFilePath)
        {
            //string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0 xml;"

            OleDbConnection connection = new OleDbConnection(
                string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;HDR=Yes;",
                excelFilePath));

            return connection;
        }

        private static void FillVendorsTotalReportsExcel(string excelFilePath, string sheetName)
        {
            OleDbConnection connection = new OleDbConnection(
                string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'",
                excelFilePath));

            connection.Open();

            using (connection)
            {
                using (var msSQLServerContext = new SupermarketEntities())
                {

                    var vendorFinalReports = VendorFinalReport.FinalReportUtilities.QueryIt();
                    
                    //var vendors =
                    //    from vendor in msSQLServerContext.Vendors
                    //    select vendor;

                    foreach (var vendor in vendorFinalReports)
                    {
                        OleDbCommand insertCommand = new OleDbCommand(
                            string.Format(
                            "INSERT INTO [NewSheet] ([Vendor], [Incomes], [Expenses], [Taxes], [Financial Result]) " +
                            "VALUES (@vendor, @incomes, @expenses, @taxes, @financialResult)"),
                            connection);

                        insertCommand.Parameters.AddWithValue("@vendor", vendor.VendorName);
                        insertCommand.Parameters.AddWithValue("@incomes", vendor.TotalIncome);
                        insertCommand.Parameters.AddWithValue("@expenses", vendor.Expenses);
                        insertCommand.Parameters.AddWithValue("@taxes", vendor.TotanTaxes);
                        insertCommand.Parameters.AddWithValue("@financialResult", vendor.Result);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private static void CreateEmptyVendorsTotalReports2(string filePath)
        {
            using (OleDbConnection connection = new OleDbConnection(
                string.Format(
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'",
                filePath)))
            {
                connection.Open();
                OleDbCommand createCommand = new OleDbCommand(
                    "CREATE TABLE [NewSheet] ([Vendor] string, [Incomes] string, [Expenses] string, [Taxes] string, [Financial Result] string)",
                    connection);
                createCommand.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
