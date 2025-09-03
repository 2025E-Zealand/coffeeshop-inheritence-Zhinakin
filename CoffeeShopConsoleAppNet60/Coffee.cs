using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public abstract class Coffee
    {
        public int Discount { get; set; }
        public string Name { get; set; }
        public CoffeeBlend Blend { get; set; }

        protected Coffee(string name, CoffeeBlend blend)
        {
            if (!Enum.IsDefined(typeof(CoffeeBlend), blend))
                throw new ArgumentException("Invalid coffee blend.", nameof(blend));

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Blend = blend;
            Discount = GetDiscountForBlend(blend);
        }

        public enum CoffeeBlend
        {
            Columbian,
            Kieni,
            Akmel,
            VistaHermosa,
            Decaf
        }

        public virtual int Price()
        {
            int basePrice = 20;
            
            if (Discount > 5)
                throw new InvalidOperationException("Discount cannot be greater than 5 kr.");

            return basePrice - Discount;
        }

        public abstract string Strength();

        private int GetDiscountForBlend(CoffeeBlend blend)
        {
            return blend switch
            {
                CoffeeBlend.Kieni => 2,
                CoffeeBlend.Akmel => 3,
                CoffeeBlend.VistaHermosa => 1,
                CoffeeBlend.Decaf => 5,
                CoffeeBlend.Columbian => -10,
                _ => 0
            };
        }
    }
}
