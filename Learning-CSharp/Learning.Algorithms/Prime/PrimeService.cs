using Learning.Algorithms.Enums;
using System;
using System.Collections.Generic;

namespace Learning.Algorithms.Prime
{
    public class PrimeService : IPrimeService
    {
        private IPrimeService _Inner;
        public PrimeAlgorithmType_Values AlgoType { get; }

        public PrimeService(PrimeAlgorithmType_Values algoType)
        {
            AlgoType = algoType;
            _Inner = GetPrimeService(algoType);
        }
        public PrimeService(IPrimeService inner)
        {
            AlgoType = inner.AlgoType;
            _Inner = inner;
        }

        private IPrimeService GetPrimeService(PrimeAlgorithmType_Values algoType)
        {
            switch (algoType)
            {
                case PrimeAlgorithmType_Values._NotDefined:
                    throw new ArgumentException($"AlgoType cannot be {algoType}.");
                case PrimeAlgorithmType_Values.BruteForce:
                    return new PrimeServiceUsingBruteForce();
                case PrimeAlgorithmType_Values.SieveOfEratosthenes:
                    return new PrimeServiceUsingSieveOfEratosthenes();
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

        public List<int> GetPrimeNumbers(int start, int end)
        {
            return _Inner.GetPrimeNumbers(start, end);
        }
    }
}
