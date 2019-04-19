using Learning.DesignPatterns.BuilderPattern;

namespace Learning.DesignPatterns.BuilderPattern
{
    class ClubSandwichBuilder : SandwichBuilder
    {
        public override void ApplyCondiments()
        {
            _Sandwich.HasMayo = true;
            _Sandwich.HasMustard = true;
        }

        public override void ApplyMeatAndCheese()
        {
            _Sandwich.MeatType = MeatType.Salami;
            _Sandwich.CheeseType = CheeseType.Swiss;
        }

        public override void ApplyVegetables()
        {
            _Sandwich.Vegetables = new System.Collections.Generic.List<string> { "Tomato", "Onion", "Lettuce" };
        }

        public override void PrepareBread()
        {
            _Sandwich.BreadType = BreadType.Wheat;
            _Sandwich.IsToasted = true;
        }
    }
}