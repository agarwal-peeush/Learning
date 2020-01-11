using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.SingletonPattern
{
    /* Sealed keyword restricts the inheritance */
    public sealed class Logger
    {
        private static Logger _Instance;

        /* Private constructor ensures that object is not 
         * instantiated other than with in the class itself. */
        private Logger()
        {

        }

        /* Public property is used to return only one instance of the class leveraging on the private property */
        public static Logger Instance
            => _Instance ?? (_Instance = new Logger()); //Lazy initialization - works well in Single-threaded environment.

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
