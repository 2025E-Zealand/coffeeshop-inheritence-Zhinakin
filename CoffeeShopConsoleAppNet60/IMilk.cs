using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public interface IMilk
    {
        MilkType Milk {  get; }
        
        public int MIMilk();

        public enum MilkType
        {
            Skummemælk,
            Minimælk,
            Sødmælk,
            Mandemælk,
            Sojamælk,
        }
    }
}
