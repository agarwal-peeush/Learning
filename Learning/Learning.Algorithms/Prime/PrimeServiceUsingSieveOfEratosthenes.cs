using Learning.Algorithms.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Learning.Algorithms.Prime
{
    public class PrimeServiceUsingSieveOfEratosthenes : IPrimeService
    {
        public PrimeAlgorithmType_Values AlgoType
            => PrimeAlgorithmType_Values.SieveOfEratosthenes;

        public bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            List<int> primes = GetPrimeNumbersWithinInput(number);
            return primes.Any(x => x == number);
        }

        public List<int> GetPrimeNumbers(int number)
        {
            return GetPrimeNumbersWithinInput(number);
        }

        public List<int> GetPrimeNumbers(int start, int end)
        {
            if (start > end)
                throw new ArgumentException($"Start(={start}) cannot be greater than End(={end})");

            return GetPrimeNumbersWithinInput(end)
                .Where(x => x >= start)
                .ToList();
        }

        private List<int> GetPrimeNumbersWithinInput(int input)
        {
            Dictionary<int, bool> primes = new Dictionary<int, bool>();

            for (int i = 2; i <= input; i++)
            {
                primes.Add(i, true);
            }

            for (int p = 2; p * p <= input; p++)
            {
                if (primes[p])
                {
                    for (int i = p * p; i <= input; i += p)
                    {
                        primes[i] = false;
                    }
                }
            }

            return primes
                .Where(x => x.Value == true)
                .Select(x => x.Key)
                .ToList();
        }
    }
}
