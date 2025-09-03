using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class BlackCoffee : Coffee
    {
        public BlackCoffee(CoffeeBlend blend) : base("Black Coffee", blend) { }

        public override string Strength()
        {
            return "Strong";
        }
    }
}
