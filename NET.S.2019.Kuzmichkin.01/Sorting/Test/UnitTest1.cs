using NUnit.Framework;
using System.Collections.Generic;
using Sorting;
using System;

namespace Tests
{
    [TestFixture]
    public class PublicTest
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new int[] { 9,8,7,6,5}, arg2: new int[] { 5, 6, 7, 8, 9 });
                yield return new TestCaseData(arg1: new int[] { 9,9,9,9,9,9,9,9,9,3 }, arg2: new int[] { 3,9,9,9,9,9,9,9,9,9 });
                yield return new TestCaseData(arg1: new int[] { 0,2,9,3,8,4,7,5,6 }, arg2: new int[] {0,2,3,4,5,6,7,8,9 });
                
            }
        }

        [TestCaseSource(nameof(DataCases))]
        public void QuickSortTest(int[] actual, int[] expected)
        {
            Sort.QuickSort(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(DataCases))]
        public void MergeSortTest(int[] actual, int[] expected)
        {
            Sort.MergeSort(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QuickSortNullExceptionTest()
        {
            int[] mas = null;
            Assert.Throws<NullReferenceException>(() => Sort.QuickSort(mas));
        }

        [Test]
        public void MergeSortNullExceptionTest()
        {
            int[] mas = null;
            Assert.Throws<NullReferenceException>(() => Sort.MergeSort(mas));
        }

        [Test]
        public void QuickSortEmptyExceptionTest()
        {
            int[] mas = new int[0];
            Assert.Throws<ArgumentException>(() => Sort.QuickSort(mas));
        }

        [Test]
        public void MergeSortEmptyExceptionTest()
        {
            int[] mas = new int[0];
            Assert.Throws<ArgumentException>(() => Sort.MergeSort(mas));
        }

    }
}