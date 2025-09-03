using CoffeeShopConsoleAppNet60;
using System.Runtime.InteropServices;

List<Coffee> coffees = new List<Coffee>
    {
        new Cortado(Coffee.CoffeeBlend.Kieni, IMilk.MilkType.Sødmælk),
        new Cortado(Coffee.CoffeeBlend.VistaHermosa, IMilk.MilkType.Minimælk),
        new Cortado(Coffee.CoffeeBlend.Columbian, IMilk.MilkType.Sojamælk),
        new Latte(Coffee.CoffeeBlend.Decaf, IMilk.MilkType.Mandemælk),
        new BlackCoffee(Coffee.CoffeeBlend.Akmel),
        new Espresso(Coffee.CoffeeBlend.Kieni)
    };

foreach  (Coffee coffee in coffees)
{
    Console.WriteLine($"{coffee.Name} of {coffee.Blend} Blend : {coffee.Price()} + {coffee.Strength()}");
}

Console.WriteLine();

List<IMilk> milkCoffees = new List<IMilk>
    {
        new Latte(Coffee.CoffeeBlend.Akmel, IMilk.MilkType.Sødmælk),
        new Cortado(Coffee.CoffeeBlend.Decaf, IMilk.MilkType.Mandemælk)
    };

foreach (var coffee in milkCoffees)
{
    Coffee c = (Coffee)coffee; // safe because all IMilk here are also Coffee
    Console.WriteLine($"{c.Name} of {c.Blend} blend, has {coffee.MIMilk()} ml milk and the milk type is: {coffee.Milk}");
}

Console.WriteLine();

// Create the order system
OrderSystem system = new OrderSystem();

// Create Order 1 (Table order)
Order order1 = system.CreateOrder("Alice", "Bob", "12");
order1.AddCoffee(new Latte(Coffee.CoffeeBlend.Kieni, IMilk.MilkType.Sødmælk));
order1.AddCoffee(new Cortado(Coffee.CoffeeBlend.VistaHermosa, IMilk.MilkType.Minimælk));
order1.AddCoffee(new Espresso(Coffee.CoffeeBlend.Decaf));

// Create Order 2 (Takeaway)
Order order2 = system.CreateOrder("Charlie", "Diana"); // TableId null → Takeaway
order2.AddCoffee(new BlackCoffee(Coffee.CoffeeBlend.Akmel));
order2.AddCoffee(new Latte(Coffee.CoffeeBlend.Decaf, IMilk.MilkType.Skummemælk));

// Print all orders summary
system.PrintSummary();

// Extra info
Console.WriteLine("=== Totals across all orders ===");
Console.WriteLine($"Total revenue: {system.TotalRevenue()} kr");
Console.WriteLine($"Total discount given: {system.TotalDiscount()} kr");
Console.WriteLine($"Total items sold: {system.TotalItems()}");

// Find orders by barista
var aliceOrders = system.FindOrdersByBarista("Alice");
Console.WriteLine($"\nOrders handled by Alice: {aliceOrders.Count}");

// Find orders by customer
var bobOrders = system.FindOrdersByCustomer("Bob");
Console.WriteLine($"Orders for Bob: {bobOrders.Count}");

// Display milk info for milk coffees
Console.WriteLine("\n=== Milk Coffees ===");
foreach (var order in system.Orders)
{
    foreach (var coffee in order.Coffees)
    {
        if (coffee is IMilk milkCoffee)
        {
            Console.WriteLine($"{coffee.Name} of {coffee.Blend}) type blend has {milkCoffee.MIMilk()} ml milk of type {milkCoffee.Milk}");
        }
    }
}