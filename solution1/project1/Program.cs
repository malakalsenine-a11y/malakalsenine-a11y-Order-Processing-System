using System;
using System.Collections.Generic;
namespace project1
{
    internal class Program
    {
        // --- 3. Base Class with Encapsulation ---
        public class Product
        {
            private string _id = string.Empty;
            private string _name = string.Empty;
            private double _price;
            private int _stockQuantity;

            public string Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public double Price { get => _price; set => _price = value; }
            public int StockQuantity { get => _stockQuantity; set => _stockQuantity = value; }

            public Product(string id, string name, double price, int stock)
            {
                _id = id; _name = name; _price = price; _stockQuantity = stock;
            }

            // Virtual method for Polymorphism
            public virtual double CalculateDiscount() => 0;
        }

        // Inheritance - Electronics
        public class ElectronicsProduct : Product
        {
            public ElectronicsProduct(string id, string name, double price, int stock)
            : base(id, name, price, stock) { }

            public override double CalculateDiscount() => Price * 0.05; // 5% Discount
        }

        // Inheritance - Clothing
        public class ClothingProduct : Product
        {
            public ClothingProduct(string id, string name, double price, int stock)
            : base(id, name, price, stock) { }

            public override double CalculateDiscount() => Price * 0.10; // 10% Discount
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
