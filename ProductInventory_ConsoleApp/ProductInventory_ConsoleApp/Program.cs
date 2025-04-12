using System;
using System.Collections.Generic;

namespace ProductInventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> inventory = new List<Product> //data added intially to perform some operattions.
            {
                new Product(1, "Laptop", 800, 10, "Electronics"),
                new Product(2, "Smartphone", 400, 20, "Electronics"),
                new Product(3, "Headphones", 200, 30, "Accessories")
            };

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== Product Inventory Management System ===");
                Console.WriteLine("1. Display All Products");
                Console.WriteLine("2. Apply Discount to a Product");
                Console.WriteLine("3. Update Stock Quantity");
                Console.WriteLine("4. Add New Product");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n=== All Products ===");
                        foreach (Product product in inventory)
                        {
                            product.DisplayProductInfo();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("\n=== Apply Discount ===");
                        Console.Write("Enter Product ID: ");
                        int productId = int.Parse(Console.ReadLine()!);
                        Product? selectedProduct = inventory.Find(p => p.ProductID == productId);

                        if (selectedProduct != null)
                        {
                            Console.Write("Enter Discount Percentage: ");
                            double discount = double.Parse(Console.ReadLine()!);
                            selectedProduct.ApplyDiscount(discount);
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }

                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("\n=== Update Stock ===");
                        Console.Write("Enter Product ID: ");
                        productId = int.Parse(Console.ReadLine()!);
                        selectedProduct = inventory.Find(p => p.ProductID == productId);

                        if (selectedProduct != null)
                        {
                            Console.Write("Enter Quantity to Add/Remove: ");
                            int quantity = int.Parse(Console.ReadLine()!);
                            selectedProduct.UpdateStock(quantity);
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }

                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Product.AddProduct(inventory);
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
