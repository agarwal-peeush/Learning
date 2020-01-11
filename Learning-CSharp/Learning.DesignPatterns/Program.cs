using Learning.DesignPatterns.BridgePattern;
using Learning.DesignPatterns.BuilderPattern;
using Learning.DesignPatterns.ChainOfResponsibilityPattern;
using Learning.DesignPatterns.CommandPattern;
using Learning.DesignPatterns.CompositePattern;
using Learning.DesignPatterns.DecoratorPattern.Component;
using Learning.DesignPatterns.DecoratorPattern.ConcreteComponent;
using Learning.DesignPatterns.DecoratorPattern.ConcreteDecorator;
using Learning.DesignPatterns.MementoPattern;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning.DesignPatterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //DemoBridgePattern();
            //DemoBuilderPattern();
            //DemoChainOfResponsibilityPattern();
            //DemoCommandPattern(args);
            //DemoCompositePattern();
            //DemoDecoratorPattern();
            //DemoMementoPattern();
            DemoSingletonPattern();

            Console.ReadKey();
        }

        private static void DemoBridgePattern()
        {
            List<Manuscript> documents = new List<Manuscript>();
            //var formatter = new StandardFormatter();
            BackwardsFormatter formatter = new BackwardsFormatter();

            FAQ faq = new FAQ(formatter)
            {
                Title = "The Bridge pattern FAQ",
            };
            faq.Questions.Add("What is it?", "A design pattern");
            faq.Questions.Add("When do we use it?", "When you need to separate an abstraction from an implementation");
            documents.Add(faq);

            Book book = new Book(formatter)
            {
                Title = "Lots of patterns",
                Author = "PA",
                Text = "qwerty qazwsx",
            };
            documents.Add(book);

            TermPaper paper = new TermPaper(formatter)
            {
                Class = "Design Patterns",
                Student = "P",
                Text = "qwerty wsx",
                References = "GOF",
            };
            documents.Add(paper);

            foreach (Manuscript doc in documents)
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
            SandwichMaker maker = new SandwichMaker(new MySandwichBuilder());
            maker.BuildSandwich();
            Sandwich sandwich = maker.GetSandwich();
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
            ExpenseHandler william = new ExpenseHandler(new Employee("William Worker", decimal.Zero));
            ExpenseHandler mary = new ExpenseHandler(new Employee("Mary Manager", 1000));
            ExpenseHandler victor = new ExpenseHandler(new Employee("Victor VicePres", 5000));
            ExpenseHandler paula = new ExpenseHandler(new Employee("Paula President", 20000));

            william.RegisterNext(mary);
            mary.RegisterNext(victor);
            victor.RegisterNext(paula);

            while (ConsoleInput.TryReadDecimal("Expense report amount:", out decimal expenseReportAmount))
            {
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);

                ApprovalResponse response = william.Approve(expense);
                Console.WriteLine($"The request was {response}.");
            }
            #endregion
        }

        private static void DemoCommandPattern(string[] args)
        {
            #region Logic without CommandPattern
            //Program1.Run(args);
            #endregion

            #region Logic following CommandPattern
            Program2.Run(args);
            #endregion
        }

        private static void DemoCompositePattern()
        {
            int goldForKill = 1023;
            Console.WriteLine("You have killed the Giant IE6 Monster and gained {0} gold!", goldForKill);

            #region Logic without CompositePattern

            //var joe = new Person { Name = "Joe" };
            //var jake = new Person { Name = "Jake" };
            //var emily = new Person { Name = "Emily" };
            //var sophia = new Person { Name = "Sophia" };
            //var brian = new Person { Name = "Brian" };
            //var developers = new Group { Name = "Developers", Members = { joe, jake, emily } };

            //var individuals = new List<Person> { sophia, brian };
            //var groups = new List<Group> { developers };

            //var totalToSplitBy = individuals.Count + groups.Count;

            //var amountForEach = goldForKill / totalToSplitBy;
            //var leftOver = goldForKill % totalToSplitBy;

            //foreach (var individual in individuals)
            //{
            //    individual.Gold += amountForEach + leftOver;
            //    leftOver = 0;
            //    individual.Stats();
            //}

            //foreach (var group in groups)
            //{
            //    var amountForEachGroupMember = amountForEach / group.Members.Count;
            //    var leftOverForGroup = amountForEachGroupMember % group.Members.Count;
            //    foreach (var member in group.Members)
            //    {
            //        member.Gold += amountForEachGroupMember + leftOverForGroup;
            //        leftOverForGroup = 0;
            //        member.Stats();
            //    }
            //}
            #endregion

            #region Logic with CompositePattern
            Person joe = new Person { Name = "Joe" };
            Person jake = new Person { Name = "Jake" };
            Person emily = new Person { Name = "Emily" };
            Person sophia = new Person { Name = "Sophia" };
            Person brian = new Person { Name = "Brian" };
            Person oldBob = new Person { Name = "Old Bob" };
            Person newBob = new Person { Name = "New Bob" };
            Group bobs = new Group { Name = "Bobs", Members = { oldBob, newBob } };
            Group developers = new Group { Name = "Developers", Members = { joe, jake, emily, bobs } };

            Group parties = new Group { Name = "Root", Members = { developers, sophia, brian } };
            parties.Gold = goldForKill;

            parties.Stats();

            #endregion
        }

        private static void DemoDecoratorPattern()
        {
            #region Without DecoratorPattern
            //LargePizza largePizza = new LargePizza();

            //Console.WriteLine(largePizza.Description);
            //Console.WriteLine("{0:C2}", largePizza.CalculateCost()); 
            #endregion

            #region With DecoratorPattern
            Pizza largePizza = new LargePizza();
            largePizza = new Cheese(largePizza);
            largePizza = new Ham(largePizza);
            largePizza = new Peppers(largePizza);

            Console.WriteLine(largePizza.GetDescription());
            Console.WriteLine("{0:C2}", largePizza.CalculateCost());
            #endregion

            Console.ReadKey();
        }

        private static void DemoMementoPattern()
        {
            var editor = new Editor();
            var history = new History();

            editor.Content = "A";
            history.Push(editor.CreateState());

            editor.Content = "B";
            history.Push(editor.CreateState());

            editor.Content = "C";
            //history.Push(editor.CreateState());

            editor.Restore(history.Pop());

            Console.WriteLine(editor.Content); //Should print "B"

            editor.Restore(history.Pop());
            Console.WriteLine(editor.Content); //Should print "A"

        }
        private static void DemoSingletonPattern()
        {
            //Multi-threaded call
            Parallel.Invoke(
                () => DemoSingleton_Object1(),
                () => DemoSingleton_Object2());

            // Single-threaded call
            //DemoSingleton_Object1();
            //DemoSingleton_Object2();
        }

        private static void DemoSingleton_Object2()
        {
            var obj2 = SingletonPattern.Logger.Instance;
            obj2.Log("Second Object message");
            Console.WriteLine(obj2.GetHashCode());
        }

        private static void DemoSingleton_Object1()
        {
            var obj1 = SingletonPattern.Logger.Instance;
            obj1.Log("First Object message");
            Console.WriteLine(obj1.GetHashCode());
        }
    }
}
