using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRulesTest.Models
{
    public abstract class Fruit
    {
        public double Price { get; set; }

        public bool IsInSeason { get; set; }
    }
}
