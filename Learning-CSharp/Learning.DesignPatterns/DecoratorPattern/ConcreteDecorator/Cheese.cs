using Learning.DesignPatterns.DecoratorPattern.Component;
using Learning.DesignPatterns.DecoratorPattern.Decorator;

namespace Learning.DesignPatterns.DecoratorPattern.ConcreteDecorator
{
    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza) : base(pizza)
        {
            Description = "Cheese";
        }

        public override double CalculateCost()
        {
            return _Pizza.CalculateCost() + 1.25;
        }

        public override string GetDescription()
        {
            return $"{_Pizza.GetDescription()}, {Description}";
        }
    }
}
