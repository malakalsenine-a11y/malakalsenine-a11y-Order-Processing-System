namespace OrderProcessingSystem
{
    // Order Item Class
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double SubTotal => (Product.Price - Product.CalculateDiscount()) * Quantity;

        public OrderItem(Product product, int quantity)
        {
            Product = product; Quantity = quantity;
        }
    }

    // Order Logic (Part 1)
    public partial class Order : IShippable
    {
        public string Id { get; set; } = string.Empty;
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public string Status { get; set; } = "Pending";
        private Payment? _paymentMethod;

        public double TotalPrice => Items.Sum(i => i.SubTotal);

        public Order(string id, Customer customer)
        {
            Id = id; Customer = customer;
        }

        public void AddProduct(Product p, int qty)
        {
            if (p.StockQuantity >= qty)
            {
                Items.Add(new OrderItem(p, qty));
                p.StockQuantity -= qty;
                Console.WriteLine("--- Product Addition Process ---");
                Console.WriteLine($"Added [{p.Name}] with quantity [{qty}] to the cart.");
            }
        }
    }
}