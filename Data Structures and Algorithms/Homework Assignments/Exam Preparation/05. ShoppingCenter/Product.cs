using System;

namespace ShoppingCenter
{
    public class Product : IComparable<Product>
    {
        public Product(string name, float price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }
        public float Price { get; set; }
        public string Producer { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
        }

        public int CompareTo(Product other)
        {
            int nameComparisonResult = this.Name.CompareTo(other.Name);

            if (nameComparisonResult == 0)
            {
                int producerComparisonResult = this.Producer.CompareTo(other.Producer);

                if (producerComparisonResult == 0)
                {
                    return this.Price.CompareTo(other.Price);
                }

                return producerComparisonResult;
            }

            return nameComparisonResult;
        }
    }
}
