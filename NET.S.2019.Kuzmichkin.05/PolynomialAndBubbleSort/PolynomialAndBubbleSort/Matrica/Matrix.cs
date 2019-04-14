using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialAndBubbleSort
{
    public static class Matrix
    {
        public static int[][] GetClone(int[][] arr)
        {
            int[][] newArray = new int[arr.Length][];
            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = new int[arr[i].Length];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    newArray[i][j] = arr[i][j];
                }
            }
            return newArray;
        }

        public static void ReverseLine(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            for (int i = 0; i < arr.Length / 2; i++)
                SwapMatrixRows(arr[i], arr[arr.Length - 1 - i]);
        }


        public static void SumSortLine(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            int[] sum = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                sum[i] = arr[i].Sum();
            BubbleSort(arr, sum);
        }

        public static void MaxSortLine(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            int[] maxElements = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {   
                maxElements[i] = arr[i].Max();
            }
            BubbleSort(arr, maxElements);
        }

        public static void MinSortLine(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            int[] minElements = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                minElements[i] = arr[i].Min();
            }
            BubbleSort(arr, minElements);
        }


        private static void BubbleSort(int[][] matrix,int[] arr)
        {
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        Swap(ref arr[sort], ref arr[sort+1]);
                        SwapMatrixRows(matrix[sort],matrix[sort+1]);
                    }
                }
            }

        }

        private static void SwapMatrixRows(int[] arr1, int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
        private static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

    }
}
