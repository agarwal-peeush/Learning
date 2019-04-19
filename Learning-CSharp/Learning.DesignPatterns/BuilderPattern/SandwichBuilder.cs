using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.BuilderPattern
{
    abstract class SandwichBuilder
    {
        protected Sandwich _Sandwich;

        public Sandwich GetSandwich()
            => _Sandwich;

        public void CreateNewSandwich()
            => _Sandwich = new Sandwich();

        public abstract void PrepareBread();
        public abstract void ApplyMeatAndCheese();
        public abstract void ApplyVegetables();
        public abstract void ApplyCondiments();
    }
}
