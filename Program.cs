using System;
using Assignment6_2B.Model;

namespace Assignment6_2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Develop a ConsoleApp to enter Order Details using properties in a simplified inventory system.
            //The application allows users to input order information such as  
            //order Id  Date  Customer ID Product ID  Product Name Quantity Rate
            //The application also provides a list of available Product IDs along with their corresponding product names for selection

            // Create an array to store products (assuming max 100 products for simplicity)
            Product[] products = new Product[100];
            int productCount = 0;

            Console.WriteLine("Enter Product Details (at least 1 product is required)");

            // Add products dynamically
            while (true)
            {
                //
                if (productCount >= products.Length)
                {
                    Console.WriteLine("Product storage is full!");
                    break;
                }

                Product product = new Product();

                Console.Write("Enter Product ID: ");
                product.ProductId = int.Parse(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                product.ProductName = Console.ReadLine();

                Console.Write("Enter Product Rate: ");
                product.Rate = double.Parse(Console.ReadLine());

                // Check for duplicate Product ID
                bool isDuplicate = false;
                for (int i = 0; i < productCount; i++)
                {
                    if (products[i].ProductId == product.ProductId)
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    products[productCount] = product;
                    productCount++;
                    Console.WriteLine("Product added successfully.\n");
                }
                else
                {
                    Console.WriteLine("Product ID already exists. Try again.\n");
                }

                Console.Write("Do you want to add another product? (yes/no): ");
                string response = Console.ReadLine().ToLower();
                if (response != "yes")
                {
                    break;
                }
            }

            // Display available products
            Console.WriteLine("\nAvailable Products:");
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"Product ID: {products[i].ProductId}, Name: {products[i].ProductName}, Rate: {products[i].Rate}");
            }

            // Create a new order
            Order order = new Order();

            Console.WriteLine("\nEnter Order Details:");

            Console.Write("Order ID: ");
            order.OrderId = int.Parse(Console.ReadLine());

            Console.Write("Order Date (YYYY-MM-DD): ");
            order.Date = DateTime.Parse(Console.ReadLine());

            Console.Write("Customer ID: ");
            order.CustomerId = int.Parse(Console.ReadLine());

            Console.Write("Product ID: ");
            order.ProductId = int.Parse(Console.ReadLine());

            // Find the selected product in the array
            Product selectedProduct = null;
            for (int i = 0; i < productCount; i++)
            {
                if (products[i].ProductId == order.ProductId)
                {
                    selectedProduct = products[i];
                    break;
                }
            }

            if (selectedProduct != null) // If product is found
            {
                order.ProductName = selectedProduct.ProductName;
                order.Rate = selectedProduct.Rate;

                Console.Write("Quantity: ");
                order.Quantity = int.Parse(Console.ReadLine());

                // Calculate total amount
                order.TotalAmount = order.Quantity * order.Rate;

                // Display order summary
                Console.WriteLine("\nOrder Summary:");
                Console.WriteLine($"Order ID: {order.OrderId}");
                Console.WriteLine($"Date: {order.Date.ToShortDateString()}");
                Console.WriteLine($"Customer ID: {order.CustomerId}");
                Console.WriteLine($"Product: {order.ProductName}");
                Console.WriteLine($"Quantity: {order.Quantity}");
                Console.WriteLine($"Rate: {order.Rate}");
                Console.WriteLine($"Total Amount: {order.TotalAmount}");
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
            }
        }
    }
}
