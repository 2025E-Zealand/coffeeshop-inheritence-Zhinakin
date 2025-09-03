using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoffeeShopConsoleAppNet60.IMilk;

namespace CoffeeShopConsoleAppNet60
{
    public class Latte : Coffee, IMilk
    {
        public Latte(CoffeeBlend blend, MilkType milkType)  : base("Latte", blend) { Milk = milkType; }

        public override int Price()
        {
            int basePrice = 40;

            if (Discount > 5)
                throw new InvalidOperationException("Discount cannot be greater than 5 kr.");

            return basePrice - Discount;
        }

        public override string Strength()
        {
            return "Weak";
        }

        public int MIMilk()
        {
            return 200;
        }
        public MilkType Milk { get; }
    }
}
