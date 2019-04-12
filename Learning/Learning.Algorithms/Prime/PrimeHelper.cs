using Learning.Algorithms.Enums;
using System;

namespace Learning.Algorithms.Prime
{
    public class PrimeHelper : IPrimeHelper
    {
        private IPrimeHelper _Inner;
        public PrimeAlgorithmType_Values _AlgoType { get; }

        public PrimeHelper(PrimeAlgorithmType_Values algoType)
        {
            _AlgoType = algoType;
            _Inner = GetPrimeHelper(algoType);
        }

        private IPrimeHelper GetPrimeHelper(PrimeAlgorithmType_Values algoType)
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
    }
}
