using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.BuilderPattern
{
    class SandwichMaker
    {
        private readonly SandwichBuilder _Builder;

        public SandwichMaker(SandwichBuilder builder)
        {
            _Builder = builder;
        }

        public void BuildSandwich()
        {
            _Builder.CreateNewSandwich();
            //Steps to create a sandwich
            _Builder.PrepareBread();
            _Builder.ApplyMeatAndCheese();
            _Builder.ApplyVegetables();
            _Builder.ApplyCondiments();
        }

        public Sandwich GetSandwich()
            => _Builder.GetSandwich();
    }
}
