using NUnit.Framework;
using System;
using System.Collections.Generic;
using WorkWithNumbers;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertNumberTests(int numberSource, int numberIn, int i, int j) => NumberFunctions.InsertNumber(numberSource, numberIn, i, j);

        [TestCase(8, 15, 9, 8)]
        public void InsertNumber_ArgumentOutOfRangeException(int numberSource, int numberIn, int i, int j)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberFunctions.InsertNumber(numberSource, numberIn, i, j));
        }




        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = null)]
        [TestCase(20, ExpectedResult = null)]
        public int? FindNextBiggerNumberTests(int number) => NumberFunctions.FindNextBiggerNumber(number);

        [TestCase(8,10000)]
        public void FindNextBiggerNumber_ReturnTime(int number, int maxExpected)
        {
            var(value, time) = NumberFunctions.FindNextBiggerNumberReturnTimeBySystemDiagnostics(number);
            Assert.IsTrue(time < maxExpected);
        }

        [TestCase(0)]
        [TestCase(-45)]
        public void FindNextBiggerNumber_ArgumentException(int number)
        {
            Assert.Throws<ArgumentException>(() => NumberFunctions.FindNextBiggerNumber(number));
        }





        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, arg2: 7, arg3: new int[] { 7, 70, 17 });


            }
        }

        [TestCaseSource(nameof(DataCases))]
        public void FilterDigitTests(int[] array, int digit, int[] expected)
        {
            int[] actual = NumberFunctions.FilterDigit(array, digit);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, 7)]
        public void FilterDigit_NullReferenceException(int[] array, int digit)
        {
            Assert.Throws<NullReferenceException>(() => NumberFunctions.FilterDigit(array, digit));
        }

        [TestCase(new int[0], 7)]
        [TestCase(new int[]{3, 4, 5, 6}, 22)]
        [TestCase(new int[] { 3, 4, 5, 6 }, -3)]
        public void FilterDigit_ArgumentException(int[] array, int digit)
        {
            Assert.Throws<ArgumentException>(() => NumberFunctions.FilterDigit(array, digit));
        }






        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRootTests(double number, int degree, double precision) => NumberFunctions.FindNthRoot(number, degree, precision);


        [TestCase(8, 15, -7, -5)]// ArgumentOutOfRangeException
        [TestCase(8, 15, -0.6, -0.1)]// ArgumentOutOfRangeException
        public void
        MethodName_Number_Degree_Precision_ArgumentOutOfRangeException(double number,
            int degree,
            double precision, double expected)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberFunctions.FindNthRoot(number, degree, precision));
        }
    }
}