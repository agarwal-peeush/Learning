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
        private static readonly object _Obj = new object();

        /* Private constructor ensures that object is not 
         * instantiated other than with in the class itself. */
        private Logger()
        {

        }

        /* Public property is used to return only one instance of the class leveraging on the private property */
        public static Logger Instance
        {
            get
            {
                if(_Instance is null) //Double checked locking
                {
                    lock (_Obj)
                    {
                        if (_Instance is null)//Lazy initialization - works well in Single-threaded environment.
                            _Instance = new Logger();
                    }
                }
                
                return _Instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
