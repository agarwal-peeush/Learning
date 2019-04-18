using Learning.Algorithms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Algorithms.Prime
{
    public interface IPrimeService
    {
        PrimeAlgorithmType_Values AlgoType { get; }
        bool IsPrime(int number);
        List<int> GetPrimeNumbers(int number);
        List<int> GetPrimeNumbers(int start, int end);
    }
}
