using MongoDB.Bson;

namespace MongoDataModels
{
    public class MongoProductReport
    {
        public ObjectId _id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string VendorName { get; set; }

        public double TotalQuantitySold { get; set; }

        public decimal TotalIncomes { get; set; }

        public override string ToString()
        {
            return string.Format(
                "ProductId: {0}; ProductName: {1}; VendorName: {2}; TotalQuantitySold: {3:N2}; TotalIncomes: {4:N2}",
                this.ProductId,
                this.ProductName,
                this.VendorName,
                this.TotalQuantitySold,
                this.TotalIncomes);
        }
    }
}
