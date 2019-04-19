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
            //    Solution: Convert ctor variables to Properties to reduce parameters in Sandwich ctor. 
            new Sandwich(BreadType.Wheat, false, CheeseType.American, MeatType.Turkey, false, false, new List<string> { "Tomato" }).Display();

        }
    }
}
