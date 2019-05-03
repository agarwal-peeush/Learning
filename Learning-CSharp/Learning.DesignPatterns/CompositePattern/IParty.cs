using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.CompositePattern
{
    interface IParty
    {
        int Gold { get; set; }

        void Stats();
    }
}
