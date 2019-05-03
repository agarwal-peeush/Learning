using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.CompositePattern
{
    #region Without Composite pattern
    //class Person
    //{
    //    public string Name { get; set; }
    //    public int Gold { get; set; }

    //    public void Stats()
    //    {
    //        Console.WriteLine("{0} has {1} gold coins.", Name, Gold);
    //    }
    //} 
    #endregion

    class Person : IParty
    {
        public string Name { get; set; }
        public int Gold { get; set; }

        public void Stats()
        {
            Console.WriteLine("{0} has {1} gold coins.", Name, Gold);
        }
    }
}
