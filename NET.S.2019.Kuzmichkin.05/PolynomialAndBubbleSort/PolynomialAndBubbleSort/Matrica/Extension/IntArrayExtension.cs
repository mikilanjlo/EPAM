using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialAndBubbleSort
{
    public static class IntArrayExtension
    {
        public static int Sum(this int[] arr)
        {
            int sum = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                sum += arr[j];
            }
            return sum;
        }

        public static int Max(this int[] arr)
        {
            int max = int.MinValue;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] > max)
                    max = arr[j];
            }
            return max;
        }

        public static int Min(this int[] arr)
        {
            int min = int.MaxValue;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] < min)
                    min = arr[j];
            }
            return min;
        }
    }
}
