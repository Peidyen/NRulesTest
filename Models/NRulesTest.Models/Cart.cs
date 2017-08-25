using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRulesTest.Models
{
    public class Cart
    {
        public double Total { get; set; }

        public IEnumerable<Fruit> FruitsInCart { get; set; }

        public void AddToTotal(double price)
        {
            Total += price;
        }
    }
}
