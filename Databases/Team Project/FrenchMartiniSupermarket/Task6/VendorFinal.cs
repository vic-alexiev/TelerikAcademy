using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class VendorFinal
    {
        public VendorFinal(string vendorName, decimal totalIncome, decimal totalTax, decimal expenses, decimal result)
        {
            this.VendorName = vendorName;
            this.TotalIncome = totalIncome;
            this.TotalTax = totalTax;
            this.Expenses = expenses;
            this.Result = result;
        }

        public string VendorName { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Expenses { get; set; }
        public decimal Result { get; set; }
    }
}
