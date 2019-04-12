using System;

namespace Learning.DesignPatterns.BridgePattern
{
    public class TermPaper : Manuscript
    {
        public string Class { get; set; }
        public string Student { get; set; }
        public string Text { get; set; }
        public string References { get; set; }

        private readonly IFormatter _Formatter;

        public TermPaper(IFormatter formatter)
        {
            _Formatter = formatter;
        }

        public override void Print()
        {
            Console.WriteLine(_Formatter.Format(nameof(Class), Class));
            Console.WriteLine(_Formatter.Format(nameof(Student), Student));
            Console.WriteLine(_Formatter.Format(nameof(Text), Text));
            Console.WriteLine(_Formatter.Format(nameof(References), References));
            Console.WriteLine();
        }
    }
}
