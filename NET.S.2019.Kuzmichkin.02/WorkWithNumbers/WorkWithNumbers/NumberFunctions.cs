using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WorkWithNumbers
{
    public class NumberFunctions

    {
        #region InsertNumber
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j)
                throw new ArgumentOutOfRangeException();
            string strNumberSource = Convert.ToString(numberSource, 2);
            while (strNumberSource.Length <= j)
                strNumberSource = "0" + strNumberSource;
            string strNumberIn = Convert.ToString(numberIn, 2);
            int length = i + strNumberIn.Length;
            while (strNumberIn.Length < length )
                strNumberIn += "0";
            while (strNumberIn.Length <= j)
                strNumberIn = "0" + strNumberIn;
            string strResult = "";
            for (int k = 0; k < strNumberSource.Length; k++)
                if (k <= strNumberSource.Length - 1 - i && k >= strNumberSource.Length - 1 - j)
                {
                    strResult += strNumberIn[k];
                }
                else
                {
                    strResult += strNumberSource[k];
                }
            return Convert.ToInt32(strResult,2);
        }
        #endregion

        #region FindNextBiggerNumber

        public static (int?,int) FindNextBiggerNumberReturnTimeByDate(int number)
        {
            DateTime StartTime = DateTime.Now;

            int? result = FindNextBiggerNumber(number);

            TimeSpan ts = DateTime.Now.Subtract(StartTime);
            return (result, ts.Milliseconds);
        }

        public static (int?, int) FindNextBiggerNumberReturnTimeBySystemDiagnostics(int number)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int? result = FindNextBiggerNumber(number);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return (result, ts.Milliseconds);
        }

        public static int? FindNextBiggerNumber(int number)
        {
            if (number <= 0)
                throw new ArgumentException();
            if (BigNumber(number))
                return null;
            bool result = false;
            int[] digits = NumberToArray(number);
            int ind = -1;
            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    int temp = digits[i];
                    digits[i] = digits[i - 1];
                    digits[i - 1] = temp;
                    result = true;
                    ind = i;
                    break;
                }
            }
            if (result)
            {
                BubbleSort(digits, ind);
                return DigitsToNumber(digits);
            }
            else
                return null;

        }

        private static int DigitsToNumber(int[] digits)
        {
            string s = "";
            for (int i = 0; i < digits.Length; i++)
            {
                s += "" + digits[i];
            }
            return Convert.ToInt32(s);
        }

        private static int[] NumberToArray(int number)
        {
            string s = "" + number;
            int[] digits = new int[s.Length];
            for (int i = s.Length - 1; i >= 0; i--)
            {
                digits[i] = number % 10;
                number /= 10;
            }
            return digits;
        }

        private static void BubbleSort(int[] A, int start)
        {
            for (int i = start; i < A.Length; i++)
                for (int j = start; j < A.Length - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }

        }

        private static bool BigNumber(int number)
        {
            string s = "" + number;
            string s2 = "" + int.MaxValue;
            if (s.Length < s2.Length)
                return false;
            return true;
        }
        #endregion

        #region FilterDigit
        
        public static int[] FilterDigit(int[] inputArray, int digit)
        {
            if (inputArray == null)
                throw new NullReferenceException();
            if (inputArray.Length == 0)
                throw new ArgumentException();
            if (digit < 0 || digit > 9)
                throw new ArgumentException();
            List<int> result = new List<int>();
            for (int i = 0; i < inputArray.Length; i++)
                if (IsConsistDigit(inputArray[i], digit))
                    if(!IsAlreadyConsistInArray(result.ToArray(), inputArray[i]))
                        result.Add(inputArray[i]);
            return result.ToArray();
        }

        private static bool  IsConsistDigit(int number, int digit)
        {
            char chDigit = digit.ToString()[0];
            string strNumber = number.ToString();
            for (int i = 0; i < strNumber.Length; i++)
                if (strNumber[i] == chDigit)
                    return true;
            return false;
        }

        private static bool IsAlreadyConsistInArray(int[] array, int number)
        {
            foreach (int numberFromArray in array)
                if (numberFromArray == number)
                    return true;
            return false;
        }
        #endregion

        #region FindNthRoot
        
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if(degree < 1)
                throw new ArgumentOutOfRangeException();
            if (precision <= 0)
                throw new ArgumentOutOfRangeException();

            var x0 = number / degree;
            var x1 = (1 / (double)degree) * ((degree - 1) * x0 + number / Pow(x0, degree - 1));

            while (Math.Abs(x1 - x0) > precision)
            {
                x0 = x1;
                x1 = (1 / (double)degree) * ((degree - 1) * x0 + number / Pow(x0, degree - 1));
            }
            int count = 0;
            while(precision < 1)
            {
                precision *= 10;
                count++;
            }
            x1 = Math.Round(x1, count);


            return x1;
        }

        private static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }

        #endregion
    }
}
