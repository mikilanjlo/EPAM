using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialAndBubbleSort
{
    public static class Matrix
    {
        public static int[,] GetClone(int[,] arr)
        {

            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            int[,] newArray = new int[rows,columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    newArray[i, j] = arr[i,j];
                }
            return newArray;
        }

        public static void ReverseLine(int[,] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            int[,] newArray = GetClone(arr);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = newArray[rows - i - 1, j];
                }
        }


        public static void SumSortLine(int[,] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            int[] sum = new int[rows];
            for (int i = 0; i < rows; i++)
                sum[i] = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    sum[i] += arr[i, j];
                }
            BubbleSort(arr, sum);
        }

        public static void MaxSortLine(int[,] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            int[] maxElements = new int[rows];
            for (int i = 0; i < rows; i++)
                maxElements[i] = 0;
            for (int i = 0; i < rows; i++)
            {
                int max = -2000000000;
                for (int j = 0; j < columns; j++)
                {
                    if (arr[i, j] > max)
                        max = arr[i, j];
                }
                maxElements[i] = max;
            }
            BubbleSort(arr, maxElements);
        }

        public static void MinSortLine(int[,] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();
            if (arr.Length < 1)
                throw new ArgumentException();
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            int[] minElements = new int[rows];
            for (int i = 0; i < rows; i++)
                minElements[i] = 0;
            for (int i = 0; i < rows; i++)
            {
                int min = 2000000000;
                for (int j = 0; j < columns; j++)
                {
                    if (arr[i, j] < min)
                        min = arr[i, j];
                }
                minElements[i] = min;
            }
            BubbleSort(arr, minElements);
        }


        private static void BubbleSort(int[,] matrix,int[] arr)
        {
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        Swap(arr,sort, sort + 1);
                        SwapMatrixLine(matrix, sort, sort + 1);
                    }
                }
            }

        }

        private static void Swap(int[] arr,int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
        private static void SwapMatrixLine(int[,] arr, int line, int nextLine)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            for (int i = 0; i < columns; i++)
            {
                int temp = arr[nextLine, i];
                arr[nextLine, i] = arr[line,i];
                arr[line,i] = temp;
            }   
        }
    }
}
