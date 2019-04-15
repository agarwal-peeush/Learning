using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Algorithms.Enums;

namespace Learning.Algorithms.Prime
{
    public class PrimeServiceUsingSieveOfEratosthenes : IPrimeService
    {
        public PrimeAlgorithmType_Values AlgoType
            => PrimeAlgorithmType_Values.SieveOfEratosthenes;

        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            var primes = GetPrimeNumbersWithinInput(number);
            return primes.Any(x => x == number);
        }

        public List<int> GetPrimeNumbers(int number)
        {
            throw new NotImplementedException();
        }

        public List<int> GetPrimeNumbers(int start, int end)
        {
            throw new NotImplementedException();
        }

        private List<int> GetPrimeNumbersWithinInput(int input)
        {
            var primes = new Dictionary<int, bool>();

            for (int i = 2; i <= input; i++)
            {
                primes.Add(i, true);
            }

            for (int p = 2; p*p <= input; p++)
            {
                if (primes[p])
                {
                    for (int i = p*p; i <= input; i += p)
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
