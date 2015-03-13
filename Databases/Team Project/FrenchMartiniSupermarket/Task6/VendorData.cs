using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorFinalReport
{
    public class VendorData
    {
        public string VendorName { set; get; }
        public decimal TotalIncome { set; get; }
        public decimal TotanTaxes { set; get; }
        public decimal Expenses { set; get; }
        public decimal Result { set; get; }

        public VendorData(string vendorName, decimal totalIncome, decimal totanTaxes, decimal expenses, decimal result)
        {
            this.VendorName = vendorName;
            this.TotalIncome = totalIncome;
            this.TotanTaxes = totanTaxes;
            this.Expenses = expenses;
            this.Result = result;
        }

        public override string ToString()
        {
            return string.Format("VendorName: {0}, TotalIncome: {1}, TotanTaxes: {2}, Expenses: {3}, Result: {4}", VendorName, TotalIncome, TotanTaxes, Expenses, Result);
        }
    }
}
