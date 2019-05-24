using Learning.DesignPatterns.DecoratorPattern.Component;

namespace Learning.DesignPatterns.DecoratorPattern.Decorator
{
    public class PizzaDecorator : Pizza
    {
        protected Pizza _Pizza;

        public PizzaDecorator(Pizza pizza)
        {
            _Pizza = pizza;
        }

        public override double CalculateCost()
        {
            return _Pizza.CalculateCost();
        }

        public override string GetDescription()
        {
            return _Pizza.GetDescription();
        }
    }
}
