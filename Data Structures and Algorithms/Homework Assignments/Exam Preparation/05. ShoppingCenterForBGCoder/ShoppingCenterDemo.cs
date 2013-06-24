using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace ShoppingCenterForBGCoder
{
    public class Command
    {
        public Command(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; private set; }

        public string[] Arguments { get; private set; }

        public static Command Parse(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "value cannot be null.");
            }

            int firstSpaceIndex = value.IndexOf(" ");
            string name = value.Substring(0, firstSpaceIndex);

            string argumentsList = value.Substring(firstSpaceIndex + 1).Trim();
            string[] arguments = argumentsList.Split(new char[] { ';' });

            Command command = new Command(name, arguments);
            return command;
        }
    }

    public class CommandProcessor
    {
        private readonly ShoppingCenterManager shoppingCenterManager;

        public CommandProcessor(ShoppingCenterManager shoppingCenterManager)
        {
            this.shoppingCenterManager = shoppingCenterManager;
        }

        public ShoppingCenterManager ShoppingCenterManager
        {
            get
            {
                return this.shoppingCenterManager;
            }
        }

        public void Process(Command command, StringBuilder output)
        {
            switch (command.Name)
            {
                case "AddProduct":
                    {
                        this.AddProduct(command.Arguments, output);
                        break;
                    }
                case "DeleteProducts":
                    {
                        this.DeleteProducts(command.Arguments, output);
                        break;
                    }
                case "FindProductsByName":
                    {
                        this.ListProductsByName(command.Arguments, output);
                        break;
                    }
                case "FindProductsByProducer":
                    {
                        this.ListProductsByProducer(command.Arguments, output);
                        break;
                    }
                case "FindProductsByPriceRange":
                    {
                        this.ListProductsByPriceRange(command.Arguments, output);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid command: " + command.Name, "command");
                    }
            }
        }

        private void AddProduct(string[] arguments, StringBuilder output)
        {
            string name = arguments[0];
            float price = float.Parse(arguments[1]);
            string producer = arguments[2];

            this.shoppingCenterManager.AddProduct(name, price, producer);

            output.AppendLine("Product added");
        }

        private void DeleteProducts(string[] arguments, StringBuilder output)
        {
            string producer;
            int productsDeleted = 0;
            if (arguments.Length == 1)
            {
                producer = arguments[0];
                productsDeleted = this.shoppingCenterManager.DeleteProductsByProducer(producer);
            }
            else if (arguments.Length == 2)
            {
                string name = arguments[0];
                producer = arguments[1];
                productsDeleted = this.shoppingCenterManager.DeleteProductsByNameAndProducer(name, producer);
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments.", "arguments");
            }

            if (productsDeleted > 0)
            {
                output.AppendLine(productsDeleted + " products deleted");
            }
            else
            {
                output.AppendLine("No products found");
            }
        }

        private void ListProductsByName(string[] arguments, StringBuilder output)
        {
            string name = arguments[0];
            var products = this.shoppingCenterManager.GetProductsByName(name);
            this.ListProducts(products, output);
        }

        private void ListProductsByProducer(string[] arguments, StringBuilder output)
        {
            string producer = arguments[0];
            var products = this.shoppingCenterManager.GetProductsByProducer(producer);
            this.ListProducts(products, output);
        }

        private void ListProductsByPriceRange(string[] arguments, StringBuilder output)
        {
            float fromPrice = float.Parse(arguments[0]);
            float toPrice = float.Parse(arguments[1]);

            var products = this.shoppingCenterManager.GetProductsByPriceRange(fromPrice, toPrice);

            this.ListProducts(products, output);
        }

        private void ListProducts(IEnumerable<Product> products, StringBuilder output)
        {
            int count = 0;
            foreach (var product in products)
            {
                count++;
                output.AppendLine(product.ToString());
            }

            if (count == 0)
            {
                output.AppendLine("No products found");
            }
        }
    }

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

    internal class ShoppingCenterDemo
    {
        private static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            ShoppingCenterManager shoppingCenterManager = new ShoppingCenterManager();
            CommandProcessor commandProcessor = new CommandProcessor(shoppingCenterManager);

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                Command command = Command.Parse(Console.ReadLine());
                commandProcessor.Process(command, resultBuilder);
            }

            Console.Write(resultBuilder);
        }
    }
}
