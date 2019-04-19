using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.BuilderPattern
{
    class MySandwichBuilder : SandwichBuilder
    {
        public override void ApplyCondiments()
        {
            _Sandwich.HasMayo = false;
            _Sandwich.HasMustard = false;
        }

        public override void ApplyVegetables()
        {
            _Sandwich.Vegetables = new List<string> { "Tomato" };
        }

        public override void ApplyMeatAndCheese()
        {
            _Sandwich.MeatType = MeatType.Turkey;
            _Sandwich.CheeseType = CheeseType.American;
        }

        public override void PrepareBread()
        {
            _Sandwich.BreadType = BreadType.Wheat;
            _Sandwich.IsToasted = false;
        }
    }
}
