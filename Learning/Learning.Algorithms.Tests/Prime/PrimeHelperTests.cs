using System;
using Learning.Algorithms.Enums;
using Learning.Algorithms.Prime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learning.Algorithms.Tests.Prime
{
    [TestClass]
    public class PrimeHelperTests
    {
        private PrimeHelper _Sut;

        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberLessThanOrEqToZero()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            var actual = _Sut.IsPrime(0);
            Assert.IsFalse(actual, "0(zero) is not a prime number");

            actual = _Sut.IsPrime(-1);
            Assert.IsFalse(actual, "-1 is not a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberIsOne()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            var actual = _Sut.IsPrime(1);
            Assert.IsFalse(actual, "1 is not a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTrue_IfNumberIsTwo()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            var actual = _Sut.IsPrime(2);
            Assert.IsTrue(actual, "2 is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTrue_IfNumberIsThree()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            var actual = _Sut.IsPrime(3);
            Assert.IsTrue(actual, "3 is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnFalse_IfNumberIsFour()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            var actual = _Sut.IsPrime(4);
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

            var actual = _Sut.IsPrime(number);
            Assert.IsTrue(actual, $"{number} is a prime number");
        }

        [TestMethod]
        public void IsPrime_ShouldReturnTimings()
        {
            _Sut = new PrimeHelper(PrimeAlgorithmType_Values.BruteForce);

            var timingsHelper = new PrimeHelperWithTimings(_Sut);

            var number = 212683;
            var result = timingsHelper.IsPrime(number);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result, $"{number} is a prime number");
            Assert.IsTrue(result.TotalTimeElapsed <= TimeSpan.FromMilliseconds(0.1));
        }
    }
}
