using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.BuilderPattern
{
    class Sandwich
    {
        private readonly BreadType _BreadType;
        private readonly bool _IsToasted;
        private readonly CheeseType _CheeseType;
        private readonly MeatType _MeatType;
        private readonly bool _HasMustard;
        private readonly bool _HasMayo;
        private readonly List<string> _Vegetables;

        public Sandwich(BreadType breadType, bool isToasted, CheeseType cheeseType, 
            MeatType meatType, bool hasMustard, bool hasMayo, List<string> vegetables)
        {
            _BreadType = breadType;
            _IsToasted = isToasted;
            _CheeseType = cheeseType;
            _MeatType = meatType;
            _HasMustard = hasMustard;
            _HasMayo = hasMayo;
            _Vegetables = vegetables;
        }

        public void Display()
        {
            Console.WriteLine($"Sandwich on {_BreadType} bread");
            if(_IsToasted)
                Console.WriteLine("Toasted");
            if(_HasMayo)
                Console.WriteLine("With Mayo");
            if(_HasMustard)
                Console.WriteLine("With Mustard");
            Console.WriteLine($"Meat: {_MeatType}");
            Console.WriteLine($"Cheese: {_CheeseType}");
            Console.WriteLine($"Veggies: ");
            foreach (var item in _Vegetables)
            {
                Console.WriteLine($"    {item}");
            }
        }
    }

    public enum BreadType
    {
        White,
        Wheat,
    }
    public enum CheeseType
    {
        American,
        Swiss,
        Cheddar,
        Provolone,
    }
    public enum MeatType
    {
        Turkey,
        Ham,
        Chicken,
        Salami,
    }
}
