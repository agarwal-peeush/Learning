using Learning.DesignPatterns.DecoratorPattern.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.DecoratorPattern.ConcreteComponent
{
    public class SmallPizza : Pizza
    {
        public SmallPizza()
        {
            Description = "Small Pizza";
        }

        public override double CalculateCost()
        {
            return 3.00;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }
}
