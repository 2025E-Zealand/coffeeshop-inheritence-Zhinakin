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