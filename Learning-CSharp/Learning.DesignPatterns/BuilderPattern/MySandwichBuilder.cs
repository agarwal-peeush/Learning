using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.BuilderPattern
{
    class MySandwichBuilder
    {
        private Sandwich _Sandwich;

        public Sandwich GetSandwich()
            => _Sandwich;

        public void CreateSandwich()
        {
            _Sandwich = new Sandwich();
            //Steps to create a sandwich
            PrepareBread();
            ApplyMeatAndCheese();
            ApplyVegetables();
            ApplyCondiments();
        }

        private void ApplyCondiments()
        {
            _Sandwich.HasMayo = false;
            _Sandwich.HasMustard = false;
        }

        private void ApplyVegetables()
        {
            _Sandwich.Vegetables = new List<string> { "Tomato" };
        }

        private void ApplyMeatAndCheese()
        {
            _Sandwich.MeatType = MeatType.Turkey;
            _Sandwich.CheeseType = CheeseType.American;
        }

        private void PrepareBread()
        {
            _Sandwich.BreadType = BreadType.Wheat;
            _Sandwich.IsToasted = false;
        }
    }
}
