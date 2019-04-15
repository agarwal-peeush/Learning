using Learning.Algorithms.Enums;
using Learning.Algorithms.Prime;
using System;
using System.Collections.Generic;

namespace Learning.Algorithms.Tests.Prime
{
    internal class MockPrimeService : IPrimeService
    {
        public PrimeAlgorithmType_Values AlgoType
            => PrimeAlgorithmType_Values._NotDefined;

        public List<int> GetPrimeNumbers(int number)
        {
            throw new NotImplementedException();
        }

        public List<int> GetPrimeNumbers(int start, int end)
        {
            throw new NotImplementedException();
        }

        public bool IsPrime(int number)
        {
            return true;
        }
    }
}
