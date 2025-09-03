using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class Espresso : Coffee
    {
        public Espresso(CoffeeBlend blend) : base("Espresso", blend) { }

        public override int Price()
        {
            int basePrice = 25;

            if (Discount > 5)
                throw new InvalidOperationException("Discount cannot be greater than 5 kr.");

            return basePrice - Discount;
        }

        public override string Strength()
        {
            return "Very Strong";
        }
    }
}
