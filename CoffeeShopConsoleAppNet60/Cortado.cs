using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoffeeShopConsoleAppNet60.IMilk;

namespace CoffeeShopConsoleAppNet60
{
    public class Cortado : Coffee, IMilk
    {
        public Cortado(CoffeeBlend blend, MilkType milkType) : base("Cortado", blend) { Milk = milkType; }

        public override int Price()
        {
            int basePrice = 25;

            if (Discount > 5)
                throw new InvalidOperationException("Discount cannot be greater than 5 kr.");

            return basePrice - Discount;
        }

        public override string Strength()
        {
            return "Medium";
        }
        public int MIMilk()
        {
            return 40;
        }
        public MilkType Milk { get; }
    }
}
