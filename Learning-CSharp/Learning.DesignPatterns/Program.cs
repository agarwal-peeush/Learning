using Learning.DesignPatterns.BridgePattern;
using Learning.DesignPatterns.BuilderPattern;
using System;
using System.Collections.Generic;

namespace Learning.DesignPatterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //DemoBridgePattern();
            DemoBuilderPattern();

            Console.ReadKey();
        }

        private static void DemoBridgePattern()
        {
            var documents = new List<Manuscript>();
            //var formatter = new StandardFormatter();
            var formatter = new BackwardsFormatter();

            var faq = new FAQ(formatter)
            {
                Title = "The Bridge pattern FAQ",
            };
            faq.Questions.Add("What is it?", "A design pattern");
            faq.Questions.Add("When do we use it?", "When you need to separate an abstraction from an implementation");
            documents.Add(faq);

            var book = new Book(formatter)
            {
                Title = "Lots of patterns",
                Author = "PA",
                Text = "qwerty qazwsx",
            };
            documents.Add(book);

            var paper = new TermPaper(formatter)
            {
                Class = "Design Patterns",
                Student = "P",
                Text = "qwerty wsx",
                References = "GOF",
            };
            documents.Add(paper);

            foreach (var doc in documents)
            {
                doc.Print();
            }
        }

        private static void DemoBuilderPattern()
        {
            //Problem 1: Complex Sandwich ctor and it can grow long and long
            //new Sandwich_Original(BreadType.Wheat, false, CheeseType.American, MeatType.Turkey, false, false, new List<string> { "Tomato" }).Display();

            //    Solution to Problem 1: Convert ctor variables to Properties to reduce parameters in Sandwich ctor. 
            //Problem 2: Now, after converting to properties, we have to remember each property to set
            //Problem 3: We have lost the Order at which Properties needs to be set. 
            //var sandwich = new Sandwich()
            //{
            //    BreadType = BreadType.Wheat,
            //    IsToasted = false,
            //    CheeseType = CheeseType.American,
            //    MeatType = MeatType.Turkey,
            //    HasMayo = false,
            //    HasMustard = false,
            //    Vegetables = new List<string> { "Tomato" },
            //};
            //sandwich.Display();

            //    Solution to Problem 2 and 3: Create SandwichBuilder which creates an object of Sandwich and method to return created object. 
            var builder = new MySandwichBuilder();
            builder.CreateSandwich();
            var sandwich = builder.GetSandwich();
            sandwich.Display();

        }
    }
}
