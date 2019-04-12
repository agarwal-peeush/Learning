using System;
using System.Collections.Generic;

namespace Learning.DesignPatterns.BridgePattern
{
    public class FAQ : Manuscript
    {
        public string Title { get; set; }
        public Dictionary<string, string> Questions { get; set; }

        private readonly IFormatter _Formatter;

        public FAQ(IFormatter formatter)
        {
            Questions = new Dictionary<string, string>();
            _Formatter = formatter;
        }

        public override void Print()
        {
            Console.WriteLine(_Formatter.Format(nameof(Title), Title));
            foreach (var item in Questions)
            {
                Console.WriteLine(_Formatter.Format(item.Key, item.Value));
            }
            Console.WriteLine();
        }
    }
}
