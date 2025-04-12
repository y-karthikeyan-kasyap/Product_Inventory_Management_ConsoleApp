using System;
using System.IO;
using System.Collections.Generic;

namespace ProductInventoryManagement
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }

        public Product(int productId, string name, double price, int stockQuantity, string category)
        {
            ProductID = productId;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            Category = category;
        }

        //fucntion to update stock quantity, where neagtive quantity value decreases the stock and positive increases the stock.
        public void UpdateStock(int quantity)
        {
            try
            {
                if (quantity < 0 && StockQuantity + quantity < 0)
                {
                    throw new InvalidOperationException("Not enough stock to remove.");
                }

                StockQuantity += quantity;
                Console.WriteLine($"Stock updated: {StockQuantity} left in stock");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Error updating stock: " + ex.Message);
            }
        }
        //function to apply discount , where discount should be given only between 0 to 100.
        public void ApplyDiscount(double percentage)
        {
            try
            {
                if (percentage < 0 || percentage > 100)
                {
                    throw new ArgumentOutOfRangeException("percentage", "Discount must be between 0 and 100.");
                }

                double discountAmount = (Price * percentage) / 100;
                Price -= discountAmount;
                Console.WriteLine($"New Price: ${Price}");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Error applying discount: " + ex.Message);
            }
        }
        //function to display all the products and its details.
        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product: {Name} (ID: {ProductID})");
            Console.WriteLine($"Price: ${Price} | Stock: {StockQuantity} | Category: {Category}");
        }
        //function to Log all the errors.
        private void LogError(Exception ex)
        {
            try
            {
                string logFilePath = "error_log.txt";
                string errorMessage = $"{DateTime.Now}: {ex.GetType().Name} - {ex.Message}\n{ex.StackTrace}\n";
                File.AppendAllText(logFilePath, errorMessage);
            }
            catch (Exception fileEx)
            {
                Console.WriteLine("Error while logging to file: " + fileEx.Message);
            }
        }
        //function to add Products.
        public static void AddProduct(List<Product> inventory)
        {
            Console.WriteLine("\n=== Add New Product ===");

            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Product Name: ");
            string? productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double productPrice = double.Parse(Console.ReadLine()!);

            Console.Write("Enter Stock Quantity: ");
            int stockQuantity = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Product Category: ");
            string? productCategory = Console.ReadLine();

            Product newProduct = new Product(productId, productName!, productPrice, stockQuantity, productCategory!);
            inventory.Add(newProduct);

            Console.WriteLine($"Product '{newProduct.Name}' added successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
