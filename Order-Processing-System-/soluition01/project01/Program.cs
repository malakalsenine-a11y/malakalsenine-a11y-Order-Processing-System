using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace project01
{
    // Payment Implementations
    public class CreditCardPayment : Payment
    {
        public override void Pay(double amount)
        {
            Console.WriteLine($"Successfully paid {amount}$ via [Credit Card].");
        }
    }

    // Order Logic (Part 2)
    public partial class Order
    {
        public void SetPayment(Payment method)
        {
            _paymentMethod = method;
        }

        public void ProcessOrder()
        {
            // Safety check (improved)
            if (_paymentMethod == null)
            {
                Console.WriteLine("Payment method not set!");
                return;
            }

            Console.WriteLine("\n--- Payment Process ---");
            Console.WriteLine("Processing payment...");

            _paymentMethod.Pay(TotalPrice);

            //  Improved status (more realistic)
            Status = "Processing";

            Console.WriteLine("Payment completed successfully.");
        }

        public void PrintSummary()
        {
            Console.WriteLine("\n--- Invoice Summary ---");

            double totalBeforeDiscount = Items.Sum(i => i.Product.Price * i.Quantity);
            double totalDiscount = Items.Sum(i => i.Product.CalculateDiscount() * i.Quantity);

            Console.WriteLine($"Total Product Price: {totalBeforeDiscount}$");
            Console.WriteLine($"Applied Discount: {totalDiscount}$");

            double tax = TotalPrice * 0.05;

            Console.WriteLine($"Tax (5%): {tax}$");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Final Total Required: {TotalPrice + tax}$");

            Console.WriteLine("\n--- Order Status ---");
            Console.WriteLine($"Current Order Status: {Status}");

            if (Status == "Processing")
            {
                Console.WriteLine("System Message: Your order is being prepared for shipping.");
            }
        }
    }

    // Main Entry Point (Execution Layer)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== ORDER PROCESSING SYSTEM =====\n");

            // 1. Customer
            Customer customer = new Customer("101", "Ahmed Mohamed", "ahmed@email.com");

            Console.WriteLine("--- Customer Details ---");
            Console.WriteLine($"Customer: {customer.Name} ({customer.Email})");
            Console.WriteLine($"ID: {customer.Id}\n");

            // 2. Products
            Product p1 = new ElectronicsProduct("1", "Laptop", 1000, 5);
            Product p2 = new ElectronicsProduct("2", "Wireless Mouse", 50, 10);

            Console.WriteLine("--- Products ---");
            Console.WriteLine($"{p1.Name} - {p1.Price}$");
            Console.WriteLine($"{p2.Name} - {p2.Price}$\n");

            // 3. Order
            Order order = new Order("500", customer);

            Console.WriteLine("--- Adding Products ---");
            order.AddProduct(p1, 1);
            order.AddProduct(p2, 2);

            // 4. Payment
            Console.WriteLine("\n--- Payment Method ---");
            order.SetPayment(new CreditCardPayment());

            // 5. Process Order
            order.ProcessOrder();

            // 6. Invoice
            order.PrintSummary();

            Console.WriteLine("\n===== END OF SYSTEM =====");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}