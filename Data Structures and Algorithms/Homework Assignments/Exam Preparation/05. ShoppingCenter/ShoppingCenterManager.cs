using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    public class ShoppingCenterManager
    {
        private OrderedMultiDictionary<float, Product> productsOrderedByPrice =
            new OrderedMultiDictionary<float, Product>(true);

        private MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
        private MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);
        private MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);

        public void AddProduct(string name, float price, string producer)
        {
            Product newProduct = new Product(name, price, producer);

            this.productsByName.Add(name, newProduct);
            this.productsByProducer.Add(producer, newProduct);

            string nameAndProducer = this.Combine(name, producer);
            this.productsByNameAndProducer.Add(nameAndProducer, newProduct);

            this.productsOrderedByPrice.Add(price, newProduct);
        }

        public int DeleteProductsByProducer(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                var productsToDelete = this.productsByProducer[producer];
                int deletedCount = productsToDelete.Count;

                foreach (var product in productsToDelete)
                {
                    this.productsByName.Remove(product.Name, product);
                    this.productsByNameAndProducer.Remove(this.Combine(product.Name, producer), product);
                    this.productsOrderedByPrice.Remove(product.Price, product);
                }

                this.productsByProducer.Remove(producer);

                return deletedCount;
            }

            return 0;
        }

        public int DeleteProductsByNameAndProducer(string name, string producer)
        {
            string nameAndProducer = this.Combine(name, producer);

            if (this.productsByNameAndProducer.ContainsKey(nameAndProducer))
            {
                var productsToDelete = this.productsByNameAndProducer[nameAndProducer];
                int deletedCount = productsToDelete.Count;

                foreach (var product in productsToDelete)
                {
                    this.productsByName.Remove(name, product);
                    this.productsByProducer.Remove(producer, product);
                    this.productsOrderedByPrice.Remove(product.Price, product);
                }

                this.productsByNameAndProducer.Remove(nameAndProducer);

                return deletedCount;
            }

            return 0;
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            if (this.productsByName.ContainsKey(name))
            {
                var extract = this.productsByName[name];
                var extractSorted =
                    from product in extract
                    orderby product ascending
                    select product;

                return extractSorted;
            }

            return new List<Product>();
        }

        public IEnumerable<Product> GetProductsByProducer(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                var extract = this.productsByProducer[producer];

                var extractSorted =
                    from product in extract
                    orderby product ascending
                    select product;

                return extractSorted;
            }

            return new List<Product>();
        }

        public IEnumerable<Product> GetProductsByPriceRange(float fromPrice, float toPrice)
        {
            var extract = productsOrderedByPrice.Range(fromPrice, true, toPrice, true).Values;

            var extractSorted =
                from product in extract
                orderby product ascending
                select product;

            return extractSorted;
        }

        private string Combine(string value1, string value2)
        {
            return value1 + ";" + value2;
        }
    }
}
