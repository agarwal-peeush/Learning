using Learning.DesignPatterns.DecoratorPattern.Component;

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
