using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCenter
{
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
}
