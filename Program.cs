using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRules;
using NRules.Fluent;
using NRules.Rules;
using NRulesTest.Models;

namespace NRulesTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting NRules test...");

            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(InSeasonDiscountRule).Assembly));

            var factory = repository.Compile();

            var session = factory.CreateSession();

            var cart = new Cart
            {
                Total = 0.0,
                FruitsInCart = new List<Fruit>
                {
                    new Orange{IsInSeason = true, Price = 4.00},
                    new Orange{IsInSeason = false, Price = 9.00}
                }
            };

            session.Insert(cart);

            session.Fire();

            Console.WriteLine("Done.  Hit enter to exit");

            Console.ReadLine();
        }
    }
}
