using System;

namespace Learning.DesignPatterns.BridgePattern
{
    public class Book : Manuscript
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        private readonly IFormatter _Formatter;

        public Book(IFormatter formatter)
        {
            _Formatter = formatter;
        }

        public override void Print()
        {
            Console.WriteLine(_Formatter.Format(nameof(Title), Title));
            Console.WriteLine(_Formatter.Format(nameof(Author), Author));
            Console.WriteLine(_Formatter.Format(nameof(Text), Text));
            Console.WriteLine();
        }
    }
}
