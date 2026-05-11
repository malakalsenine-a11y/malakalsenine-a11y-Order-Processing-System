using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessingSystem
{
    // 1. Interfaces
    public interface IPayable { void Pay(double amount); }
    public interface IShippable { void Ship(); }

    // 2. Abstraction
    public abstract class Payment : IPayable
    {
        public abstract void Pay(double amount);
    }

    // 3. Customer Class
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Customer(string id, string name, string email)
        {
            Id = id; Name = name; Email = email;
        }
    }
}