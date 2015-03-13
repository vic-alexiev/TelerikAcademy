using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataModels
{
    public class MongoVendorExpense
    {
        public ObjectId _id { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return string.Format(
                "VendorId: {0}; Month: {1}; Year: {2}; Amount: {3:N2}",
                this.VendorName,
                this.Month,
                this.Year,
                this.Amount);
        }
    }
}
