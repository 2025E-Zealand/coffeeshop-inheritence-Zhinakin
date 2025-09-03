using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShopConsoleAppNet60
{
    public class OrderSystem
    {
        private readonly List<Order> _orders = new List<Order>();
        private int _nextOrderId = 1;

        public IReadOnlyList<Order> Orders => _orders.AsReadOnly();

        public Order CreateOrder(string baristaName, string customerName, string? tableId = null)
        {
            var order = new Order(_nextOrderId++, baristaName, customerName, tableId);
            _orders.Add(order);
            return order;
        }

        public bool RemoveOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                _orders.Remove(order);
                return true;
            }
            return false;
        }

        public List<Order> FindOrdersByCustomer(string customerName)
        {
            return _orders.Where(o => o.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Order> FindOrdersByBarista(string baristaName)
        {
            return _orders.Where(o => o.BaristaName.Equals(baristaName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public int TotalRevenue()
        {
            return _orders.Sum(o => o.TotalPrice());
        }

        public int TotalDiscount()
        {
            return _orders.Sum(o => o.TotalDiscount());
        }

        public int TotalItems()
        {
            return _orders.Sum(o => o.TotalItems());
        }

        // Optional: Print summary of all orders
        public void PrintSummary()
        {
            foreach (var order in _orders)
            {
                Console.WriteLine(order);
                foreach (var coffee in order.Coffees)
                {
                    Console.WriteLine($" - {coffee.Name} ({coffee.Blend}), price: {coffee.Price()} kr, discount: {coffee.Discount} kr");
                }
                Console.WriteLine($"Total order price: {order.TotalPrice()} kr");
                Console.WriteLine();
            }
        }
    }
}
