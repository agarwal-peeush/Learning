using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.SingletonPattern
{
    public sealed class Logger
    {
        private static Logger _Instance;

        private Logger()
        {

        }

        public static Logger Instance
            => _Instance ?? (_Instance = new Logger());

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
