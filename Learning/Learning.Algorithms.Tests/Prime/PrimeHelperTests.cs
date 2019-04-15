using Learning.Algorithms.Enums;
using Learning.Algorithms.Prime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Learning.Algorithms.Tests.Prime
{
    [TestClass]
    public class PrimeHelperTests
    {
        private IPrimeService _Sut;

        #region IsPrime
        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberLessThanOrEqToZero()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            bool actual = _Sut.IsPrime(0);
            Assert.IsFalse(actual, "0(zero) is not a prime number");

            actual = _Sut.IsPrime(-1);
            Assert.IsFalse(actual, "-1 is not a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberIsOne()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            bool actual = _Sut.IsPrime(1);
            Assert.IsFalse(actual, "1 is not a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTrue_IfNumberIsTwo()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            bool actual = _Sut.IsPrime(2);
            Assert.IsTrue(actual, "2 is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTrue_IfNumberIsThree()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            bool actual = _Sut.IsPrime(3);
            Assert.IsTrue(actual, "3 is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberIsFour()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            bool actual = _Sut.IsPrime(4);
            Assert.IsFalse(actual, "4 is not a prime number");
        }

        [TestMethod]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(11)]
        [DataRow(13)]
        public void IsPrime_ShouldReturnTrue_IfNumberIsPrime(int number)
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            bool actual = _Sut.IsPrime(number);
            Assert.IsTrue(actual, $"{number} is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTimings()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            PrimeHelperWithTimings timingsHelper = new PrimeHelperWithTimings(_Sut);

            int number = 212683;
            PrimeHelperWithTimings.ResultWithTimings<bool> result = timingsHelper.IsPrime(number);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result, $"{number} is a prime number");
            Assert.IsTrue(result.TotalTimeElapsed <= TimeSpan.FromMilliseconds(0.9));
        }

        #endregion

        #region GetPrimeNumbers(number)
        [TestMethod]
        public void GetPrimeNumbers_ShouldReturnTwoForInputTwo()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);
            int input = 2;
            List<int> expectedPrimes = new List<int> { 2 };

            List<int> primes = _Sut.GetPrimeNumbers(input);

            CollectionAssert.AreEqual(expectedPrimes, primes);
        }

        [TestMethod]
        public void GetPrimeNumbers_ShouldReturnTwoAndThreeForInputThree()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);
            int input = 3;
            List<int> expectedPrimes = new List<int> { 2, 3 };

            List<int> primes = _Sut.GetPrimeNumbers(input);

            CollectionAssert.AreEqual(expectedPrimes, primes);
        }

        [TestMethod]
        public void GetPrimeNumbers_ShouldReturnAllPrimesForGivenInput()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            Assert_GetPrimeNumbers_ReturnsExpectedPrimes(4, new List<int> { 2, 3 });
            Assert_GetPrimeNumbers_ReturnsExpectedPrimes(5, new List<int> { 2, 3, 5 });
            Assert_GetPrimeNumbers_ReturnsExpectedPrimes(6, new List<int> { 2, 3, 5 });
            Assert_GetPrimeNumbers_ReturnsExpectedPrimes(7, new List<int> { 2, 3, 5, 7 });
            Assert_GetPrimeNumbers_ReturnsExpectedPrimes(10, new List<int> { 2, 3, 5, 7 });
            Assert_GetPrimeNumbers_ReturnsExpectedPrimes(11, new List<int> { 2, 3, 5, 7, 11 });
        }

        private void Assert_GetPrimeNumbers_ReturnsExpectedPrimes(int input, List<int> expectedPrimes)
        {
            List<int> primes = _Sut.GetPrimeNumbers(input);

            CollectionAssert.AreEqual(expectedPrimes, primes);
        }

        #endregion


        [TestMethod]
        public void InstantiateWithPrimeHelper_ShouldReturnAlgoTypeCorrectly()
        {
            MockPrimeHelper innerPrimeHelper = new MockPrimeHelper();

            _Sut = new PrimeHelper(innerPrimeHelper);

            PrimeAlgorithmType_Values algoType = _Sut.AlgoType;

            Assert.AreEqual(PrimeAlgorithmType_Values._NotDefined, algoType);
        }
    }

    internal class MockPrimeHelper : IPrimeService
    {
        public PrimeAlgorithmType_Values AlgoType
            => PrimeAlgorithmType_Values._NotDefined;

        public List<int> GetPrimeNumbers(int number)
        {
            throw new NotImplementedException();
        }

        public bool IsPrime(int number)
        {
            return true;
        }
    }
}
