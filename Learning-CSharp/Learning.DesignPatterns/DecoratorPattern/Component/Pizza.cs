namespace Learning.DesignPatterns.DecoratorPattern.Component
{
    public abstract class Pizza
    {
        public string Description { get; set; }
        public abstract double CalculateCost();
        public abstract string GetDescription();
    }
}
