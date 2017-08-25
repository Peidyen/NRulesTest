using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRules.Fluent.Dsl;
using NRulesTest.Models;

namespace NRules.Rules
{
    public class InSeasonDiscountRule : Rule
    {
        public override void Define()
        {
            Fruit fruit = null;
            Cart cart = null;

            When()
                .Match<Fruit>(() => fruit, x => x.IsInSeason)
                .Query(() => cart.FruitsInCart, x => x.Match<Fruit>(a => a.IsInSeason).Collect().Where(a => a.Any()));

            Then()
                .Do(x => cart.FruitsInCart.ToList().ForEach(a => cart.AddToTotal(a.Price)));
        }
    }
}
