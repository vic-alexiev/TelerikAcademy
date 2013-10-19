using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Cooking
{
    private static class UnitConverter
    {
        public static decimal FromCups(decimal quantity, string units)
        {
            switch (units)
            {
                case "tablespoons":
                case "tbsps":
                    {
                        return quantity * 16.0M;
                    }
                case "liters":
                case "ls":
                    {
                        return quantity * 6.0M / 25.0M;
                    }

                case "fluid ounces":
                case "fl ozs":
                    {
                        return quantity * 8.0M;
                    }
                case "teaspoons":
                case "tsps":
                    {
                        return quantity * 48.0M;
                    }

                case "gallons":
                case "gals":
                    {
                        return quantity / 16.0M;
                    }
                case "pints":
                case "pts":
                    {
                        return quantity / 2.0M;
                    }
                case "quarts":
                case "qts":
                    {
                        return quantity / 4.0M;
                    }
                case "cups":
                    {
                        return quantity;
                    }
                case "milliliters":
                case "mls":
                    {
                        return quantity * 240.0M;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid unit type.");
                    }
            }
        }

        public static decimal ToCups(decimal quantity, string units)
        {
            switch (units)
            {
                case "tablespoons":
                case "tbsps":
                    {
                        return quantity / 16.0M;
                    }
                case "liters":
                case "ls":
                    {
                        return quantity * 25.0M / 6.0M;
                    }

                case "fluid ounces":
                case "fl ozs":
                    {
                        return quantity / 8.0M;
                    }
                case "teaspoons":
                case "tsps":
                    {
                        return quantity / 48.0M;
                    }

                case "gallons":
                case "gals":
                    {
                        return quantity * 16.0M;
                    }
                case "pints":
                case "pts":
                    {
                        return quantity * 2.0M;
                    }
                case "quarts":
                case "qts":
                    {
                        return quantity * 4.0M;
                    }
                case "cups":
                    {
                        return quantity;
                    }
                case "milliliters":
                case "mls":
                    {
                        return quantity / 240.0M;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid unit type.");
                    }
            }
        }
    }

    private class Ingredient
    {
        public string Name { get; private set; }
        public decimal QuantityInCups { get; private set; }
        public string OriginalUnits { get; private set; }

        public Ingredient(string name, decimal quantity, string units)
        {
            this.Name = name;
            this.OriginalUnits = units;
            this.QuantityInCups = UnitConverter.ToCups(quantity, units);
        }

        public void AddQuantity(decimal quantity, string units)
        {
            this.QuantityInCups += UnitConverter.ToCups(quantity, units);
        }

        public void SubtractQuantity(decimal quantity, string units)
        {
            this.QuantityInCups -= UnitConverter.ToCups(quantity, units);
        }

        public override string ToString()
        {
            return String.Format("{0:F2}:{1}:{2}",
                UnitConverter.FromCups(QuantityInCups, OriginalUnits),
                OriginalUnits, Name);
        }
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // get the recipe ingredients
        int recipeIngredientsCount = Int32.Parse(Console.ReadLine());

        List<Ingredient> recipeIngredients = new List<Ingredient>();

        for (int i = 0; i < recipeIngredientsCount; i++)
        {
            string ingredient = Console.ReadLine();
            string[] ingredientData = ingredient.Split(':');

            string name = ingredientData[2];
            string units = ingredientData[1];
            decimal quantity = Decimal.Parse(ingredientData[0]);

            int searchIndex = recipeIngredients.FindIndex(p => String.Compare(p.Name, name, true) == 0);

            // if the ingredient is already in the recipe, add the new quantity
            if (searchIndex >= 0)
            {
                recipeIngredients[searchIndex].AddQuantity(quantity, units);
            }
            else
            {
                recipeIngredients.Add(new Ingredient(name, quantity, units));
            }
        }

        // get the ingredients used so far
        int usedIngredientsCount = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < usedIngredientsCount; i++)
        {
            string ingredient = Console.ReadLine();
            string[] ingredientData = ingredient.Split(':');

            string name = ingredientData[2];
            string units = ingredientData[1];
            decimal quantity = Decimal.Parse(ingredientData[0]);

            int searchIndex = recipeIngredients.FindIndex(p => String.Compare(p.Name, name, true) == 0);

            if (searchIndex >= 0)
            {
                recipeIngredients[searchIndex].SubtractQuantity(quantity, units);
            }
        }

        // print the remaining quantities
        foreach (Ingredient recipeIngredient in recipeIngredients)
        {
            if (recipeIngredient.QuantityInCups > Decimal.Zero)
            {
                Console.WriteLine(recipeIngredient);
            }
        }
    }
}
