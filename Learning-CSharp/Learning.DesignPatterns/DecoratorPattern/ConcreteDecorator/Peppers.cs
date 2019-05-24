using Learning.DesignPatterns.DecoratorPattern.Component;
using Learning.DesignPatterns.DecoratorPattern.Decorator;

namespace Learning.DesignPatterns.DecoratorPattern.ConcreteDecorator
{
    public class Peppers : PizzaDecorator
    {
        public Peppers(Pizza pizza) : base(pizza)
        {
            Description = "Peppers";
        }

        public override double CalculateCost()
        {
            return _Pizza.CalculateCost() + 2.00;
        }

        public override string GetDescription()
        {
            return $"{_Pizza.GetDescription()}, {Description}";
        }
    }
}
