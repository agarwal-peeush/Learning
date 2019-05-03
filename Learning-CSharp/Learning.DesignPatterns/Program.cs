using Learning.DesignPatterns.BridgePattern;
using Learning.DesignPatterns.BuilderPattern;
using Learning.DesignPatterns.ChainOfResponsibilityPattern;
using Learning.DesignPatterns.CommandPattern;
using System;
using System.Collections.Generic;

namespace Learning.DesignPatterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //DemoBridgePattern();
            //DemoBuilderPattern();
            //DemoChainOfResponsibilityPattern();
            DemoCommandPattern(args);

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
            //Problem 4: If we introduce new Builder, it doesn't know steps to build a sandwich. 
            //var builder = new MySandwichBuilder();
            //builder.CreateSandwich();
            //var sandwich = builder.GetSandwich();
            //sandwich.Display();

            //      Solution to Problem 4: Create SandwichMaker which handles the process/steps of building a Sandwich. It uses the builder passed to build a Sandwich
            var maker = new SandwichMaker(new MySandwichBuilder());
            maker.BuildSandwich();
            var sandwich = maker.GetSandwich();
            sandwich.Display();


            maker = new SandwichMaker(new ClubSandwichBuilder());
            maker.BuildSandwich();
            sandwich = maker.GetSandwich();
            sandwich.Display();

        }

        private static void DemoChainOfResponsibilityPattern()
        {
            #region Problem of Logic to handle expenseReport is captured at wrong level.
            /* Caller is responsible for iterating over the list. 
             * This means, business logic of how expenseReport is promoted in Management chain is captured at the wrong level.
             * I should not be worried about getting approval of my expense report in Management chain. My manager should do it for me. 
             * With the Chain of Responsibility pattern, we'll able to achieve the abstraction required behind the scenes. 
             */
            //var employees = new List<Employee>
            //{
            //    new Employee("William Worker", decimal.Zero),
            //    new Employee("Mary Manager", 1000),
            //    new Employee("Victor VicePres", 5000),
            //    new Employee("Paula President", 20000),
            //};

            //decimal expenseReportAmount;
            //while(ConsoleInput.TryReadDecimal("Expense report amount:", out expenseReportAmount))
            //{
            //    IExpenseReport expense = new ExpenseReport(expenseReportAmount);

            //    bool expenseProcessed = false;

            //    foreach (var approver in employees)
            //    {
            //        var response = approver.ApproveResponse(expense);
            //        if (response != ApprovalResponse.BeyondApprovalLimit)
            //        {
            //            Console.WriteLine($"The request was {response}.");
            //            expenseProcessed = true;
            //            break;
            //        }
            //    }

            //    if (!expenseProcessed)
            //    {
            //        Console.WriteLine("No one was able to approve your expense.");
            //    }
            //}
            #endregion

            #region Solution through Chain of Responsibility pattern
            var william = new ExpenseHandler(new Employee("William Worker", decimal.Zero));
            var mary = new ExpenseHandler(new Employee("Mary Manager", 1000));
            var victor = new ExpenseHandler(new Employee("Victor VicePres", 5000));
            var paula = new ExpenseHandler(new Employee("Paula President", 20000));

            william.RegisterNext(mary);
            mary.RegisterNext(victor);
            victor.RegisterNext(paula);

            decimal expenseReportAmount;
            while (ConsoleInput.TryReadDecimal("Expense report amount:", out expenseReportAmount))
            {
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);

                var response = william.Approve(expense);
                Console.WriteLine($"The request was {response}.");
            }
            #endregion
        }

        private static void DemoCommandPattern(string[] args)
        {
            #region Logic without CommandPattern
            Program1.Run(args);
            #endregion
        }
    }
}
