using Learning.DesignPatterns.DecoratorPattern.Component;

namespace Learning.DesignPatterns.DecoratorPattern.ConcreteComponent
{
    public class MediumPizza : Pizza
    {
        public MediumPizza()
        {
            Description = "Medium Pizza";
        }

        public override double CalculateCost()
        {
            return 6.00;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }
}
