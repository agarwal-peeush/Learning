using Learning.Algorithms.Enums;
using System;
using System.Collections.Generic;

namespace Learning.Algorithms.Prime
{
    public class PrimeHelper : IPrimeService
    {
        private IPrimeService _Inner;
        public PrimeAlgorithmType_Values AlgoType { get; }

        public PrimeHelper(PrimeAlgorithmType_Values algoType)
        {
            AlgoType = algoType;
            _Inner = GetPrimeHelper(algoType);
        }
        public PrimeHelper(IPrimeService inner)
        {
            AlgoType = inner.AlgoType;
            _Inner = inner;
        }

        private IPrimeService GetPrimeHelper(PrimeAlgorithmType_Values algoType)
        {
            switch (algoType)
            {
                case PrimeAlgorithmType_Values._NotDefined:
                    throw new ArgumentException($"AlgoType cannot be {algoType}.");
                case PrimeAlgorithmType_Values.BruteForce:
                    return new BruteForcePrimeHelper();
                default:
                    throw new NotImplementedException($"{algoType} is not implemented yet.");
            }
        }

        public bool IsPrime(int number)
        {
            return _Inner.IsPrime(number);
        }

        public List<int> GetPrimeNumbers(int number)
        {
            return _Inner.GetPrimeNumbers(number);
        }
    }
}
