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

    /* Sealed keyword restricts the inheritance */
    public sealed class Logger_EagerLoading
    {
        private static readonly Logger_EagerLoading _Instance = new Logger_EagerLoading();

        /* Private constructor ensures that object is not 
         * instantiated other than with in the class itself. */
        private Logger_EagerLoading()
        {

        }

        /* Public property is used to return only one instance of the class leveraging on the private property */
        public static Logger_EagerLoading Instance
        {
            get
            {
                return _Instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    /* Sealed keyword restricts the inheritance */
    public sealed class Logger_LazyButEagerLoading
    {
        /* Lazy handles multi-threading calls */
        private static readonly Lazy<Logger_LazyButEagerLoading> _Instance = new Lazy<Logger_LazyButEagerLoading>(() => new Logger_LazyButEagerLoading());

        /* Private constructor ensures that object is not 
         * instantiated other than with in the class itself. */
        private Logger_LazyButEagerLoading()
        {

        }

        /* Public property is used to return only one instance of the class leveraging on the private property */
        public static Logger_LazyButEagerLoading Instance
        {
            get
            {
                return _Instance.Value;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
