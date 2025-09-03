using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShopConsoleAppNet60
{
    public class Order
    {
        public int OrderId { get; }
        public string BaristaName { get; set; }
        public string CustomerName { get; set; }
        public string? TableId { get; set; } // null if takeaway
        public bool IsTakeAway => string.IsNullOrEmpty(TableId);

        public List<Coffee> Coffees { get; } = new List<Coffee>();

        public Order(int orderId, string baristaName, string customerName, string? tableId = null)
        {
            OrderId = orderId;
            BaristaName = baristaName ?? throw new ArgumentNullException(nameof(baristaName));
            CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
            TableId = tableId; // null means takeaway
        }

        public int TotalPrice()
        {
            return Coffees.Sum(c => c.Price());
        }

        public int TotalItems()
        {
            return Coffees.Count;
        }

        public int TotalDiscount()
        {
            return Coffees.Sum(c => c.Discount);
        }

        public void AddCoffee(Coffee coffee)
        {
            Coffees.Add(coffee);
        }

        public override string ToString()
        {
            string location = IsTakeAway ? "Take Away" : $"Table {TableId}";
            return $"Order {OrderId} for {CustomerName} (served by {BaristaName}) at {location}";
        }
    }
}
