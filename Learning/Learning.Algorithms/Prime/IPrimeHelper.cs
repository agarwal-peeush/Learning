using Learning.Algorithms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Algorithms.Prime
{
    public interface IPrimeHelper
    {
        PrimeAlgorithmType_Values AlgoType { get; }
        bool IsPrime(int number);
    }
}
