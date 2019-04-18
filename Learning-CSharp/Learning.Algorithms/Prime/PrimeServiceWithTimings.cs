using System;
using System.Diagnostics;

namespace Learning.Algorithms.Prime
{
    public class PrimeServiceWithTimings
    {
        private readonly IPrimeService _Inner;

        public PrimeServiceWithTimings(IPrimeService inner)
        {
            _Inner = inner;
        }

        public ResultWithTimings<bool> IsPrime(int number)
        {
            var stopwatch = Stopwatch.StartNew();
            var isPrime = _Inner.IsPrime(number);
            var elapsed = stopwatch.Elapsed;

            var result = new ResultWithTimings<bool>
            {
                Result = isPrime,
                TotalTimeElapsed = elapsed,
            };

            return result;
        }

        public class ResultWithTimings<T>
        {
            public T Result { get; set; }
            public TimeSpan TotalTimeElapsed { get; set; }
        }
    }
}
