﻿using System;
using System.Collections.Generic;
using Learning.Algorithms.Enums;

namespace Learning.Algorithms.Prime
{
    internal class PrimeServiceUsingBruteForce : IPrimeService
    {
        public PrimeAlgorithmType_Values AlgoType
            => PrimeAlgorithmType_Values.BruteForce;

        public List<int> GetPrimeNumbers(int number)
        {
            var primes = new List<int>();

            for (int i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                    primes.Add(i);
            }

            return primes;
        }

        public List<int> GetPrimeNumbers(int start, int end)
        {
            if (start > end)
                throw new ArgumentException($"Start(={start}) cannot be greater than End(={end})");

            var primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                    primes.Add(i);
            }

            return primes;
        }

        public bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
