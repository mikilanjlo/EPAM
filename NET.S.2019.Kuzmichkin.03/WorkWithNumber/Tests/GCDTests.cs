using System;
//using System.Collections.Generic;
//using System.Text;
//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkWithNumber2Part;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GcdTests
    {

        [TestCase(16, new int[] { 64, 48 })]
        [TestCase(3, new int[] { 111, 432, 96 })]
        [TestCase(1, new int[] { 661, 113, 13 })]
        public void Test_EvklidRecursion_Correct_Data(int expected, params int[] numbers)
        {
            //int expected = 16;
            Assert.AreEqual(expected, GCD.EuclideanAlgorithm(numbers));
        }

        [Test]
        public void Test_EvklidRecursion_Null_Array()
        {

            TimeSpan time = new TimeSpan();
            Assert.Throws
                <ArgumentNullException>(() => GCD.EuclideanAlgorithm(null));
        }

        [Test]
        public void Test_EvklidRecursion_Array_Length_Less_Than_1()
        {

            TimeSpan time = new TimeSpan();
            Assert.Throws<ArgumentException>(() => GCD.EuclideanAlgorithm(new int[] { }));
        }

        [TestCase(16, new int[] { 64, 48 })]
        [TestCase(3, new int[] { 111, 432, 96 })]
        [TestCase(1, new int[] { 661, 113, 13 })]
        public void Test_SteinRecursion_Correct_Data(int expected, params int[] numbers)
        {
            //int expected = 16;
            TimeSpan time = new TimeSpan();
            Assert.AreEqual(expected, GCD.EuclideanAlgorithm(numbers));
        }

        [Test]
        public void Test_SteinRecursion_Null_Array()
        {

            TimeSpan time = new TimeSpan();
            Assert.Throws<ArgumentNullException>(() => GCD.BynaryAlgorithm(null));
        }

        [Test]
        public void Test_SteinRecursion_Array_Length_Less_Than_1()
        {

            TimeSpan time = new TimeSpan();
            Assert.Throws<ArgumentException>(() => GCD.BynaryAlgorithm(new int[] { }));
        }
    }
}
