﻿using System;
using System.Collections.Generic;
using Learning.Algorithms.Enums;
using Learning.Algorithms.Prime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learning.Algorithms.Tests.Prime
{
    [TestClass]
    public class PrimeServiceUsingSieveOfEratosthenesTests
    {
        private IPrimeService _Sut;

        #region IsPrime
        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberLessThanOrEqToZero()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

            bool actual = _Sut.IsPrime(0);
            Assert.IsFalse(actual, "0(zero) is not a prime number");

            actual = _Sut.IsPrime(-1);
            Assert.IsFalse(actual, "-1 is not a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberIsOne()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

            bool actual = _Sut.IsPrime(1);
            Assert.IsFalse(actual, "1 is not a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTrue_IfNumberIsTwo()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

            bool actual = _Sut.IsPrime(2);
            Assert.IsTrue(actual, "2 is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTrue_IfNumberIsThree()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

            bool actual = _Sut.IsPrime(3);
            Assert.IsTrue(actual, "3 is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberIsFour()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

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
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

            bool actual = _Sut.IsPrime(number);
            Assert.IsTrue(actual, $"{number} is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTimings()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

            PrimeServiceWithTimings timingsHelper = new PrimeServiceWithTimings(_Sut);

            int number = 212683;
            PrimeServiceWithTimings.ResultWithTimings<bool> result = timingsHelper.IsPrime(number);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result, $"{number} is a prime number");
            Assert.IsTrue(result.TotalTimeElapsed <= TimeSpan.FromMilliseconds(30)); //Slower than SieveOfEratosthenes
        }

        #endregion

        #region GetPrimeNumbers(number)
        [TestMethod]
        public void GetPrimeNumbers_ShouldReturnEmptyForInputOne()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);
            int input = 1;
            List<int> expectedPrimes = new List<int> { };

            List<int> primes = _Sut.GetPrimeNumbers(input);

            CollectionAssert.AreEqual(expectedPrimes, primes);
        }
        [TestMethod]
        public void GetPrimeNumbers_ShouldReturnTwoForInputTwo()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);
            int input = 2;
            List<int> expectedPrimes = new List<int> { 2 };

            List<int> primes = _Sut.GetPrimeNumbers(input);

            CollectionAssert.AreEqual(expectedPrimes, primes);
        }

        [TestMethod]
        public void GetPrimeNumbers_ShouldReturnTwoAndThreeForInputThree()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);
            int input = 3;
            List<int> expectedPrimes = new List<int> { 2, 3 };

            List<int> primes = _Sut.GetPrimeNumbers(input);

            CollectionAssert.AreEqual(expectedPrimes, primes);
        }

        [TestMethod]
        public void GetPrimeNumbers_ShouldReturnAllPrimesForGivenInput()
        {
            _Sut = new PrimeService(PrimeAlgorithmType_Values.SieveOfEratosthenes);

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
    }
}
