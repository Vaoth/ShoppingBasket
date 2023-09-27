using System;
using System.Globalization;

namespace ShoppingBasket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double limitWeight = 20.0;

            List<Product> products = createListFromFile("list.txt", limitWeight);
            
            List<List<Product>> baskets = calculateBaskets(
                products.OrderByDescending(p => p.Weight).ToList(),
                limitWeight
                );

            Console.WriteLine($"With our list of {products.Count} products, we would need {baskets.Count} trips to the super market:\n");
            for (int i = 0; i < baskets.Count; i++) {
                Console.WriteLine($"Basket #{i}: {String.Concat(baskets[i].Select(p => $"{p.Name} ({p.Weight} kg) "))}");
                Console.WriteLine($"TOTAL: {baskets[i].Sum(p => p.Weight)} kg");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static List<Product> createListFromFile(string filename, double limitWeight) {
            List<Product> products = new List<Product>();
            string[] lines = File.ReadAllLines(filename);
            for (uint i = 0; i < lines.Length; i++) {
                string[] args = lines[i].Split(',');

                if (args.Length != 2) 
                    continue;

                double weight;
                if (!double.TryParse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture, out weight)) 
                    continue;

                if (weight > limitWeight) {
                    Console.WriteLine($"Warning: Product '{args[0]}' not added as its weight ({weight} kg) is over limit of {limitWeight} kg");
                    continue;
                }

                Product product = new Product(i, args[0], weight);
                products.Add(product);
            }
            return products;
        }

        static List<List<Product>> calculateBaskets(List<Product> products, double limitWeight) {
            List<List<Product>> baskets = new List<List<Product>>();
            while (products.Count > 0)
            {
                int i = 0;
                double totalWeight = 0;
                List<Product> currentBasket = new List<Product>();

                while (totalWeight <= limitWeight && i < products.Count)
                {
                    Product product = products[i++];
                    if (totalWeight + product.Weight <= limitWeight)
                    {
                        totalWeight += product.Weight;
                        currentBasket.Add(product);
                        products.Remove(product);
                        i = 0;
                    }
                }
                baskets.Add(currentBasket);
            }
            return baskets;
        }
    }
}