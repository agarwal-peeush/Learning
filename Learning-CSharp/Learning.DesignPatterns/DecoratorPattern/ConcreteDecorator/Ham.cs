using Learning.DesignPatterns.DecoratorPattern.Component;
using Learning.DesignPatterns.DecoratorPattern.Decorator;

namespace Learning.DesignPatterns.DecoratorPattern.ConcreteDecorator
{
    public class Ham : PizzaDecorator
    {
        public Ham(Pizza pizza) : base(pizza)
        {
            Description = "Ham";
        }

        public override double CalculateCost()
        {
            return _Pizza.CalculateCost() + 1.00;
        }

        public override string GetDescription()
        {
            return $"{_Pizza.GetDescription()}, {Description}";
        }
    }
}
