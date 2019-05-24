using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.DecoratorPattern.Component
{
    public abstract class Pizza
    {
        public string Description { get; set; }
        public abstract double CalculateCost();
        public abstract string GetDescription();
    }
}
