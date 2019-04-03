using System;
using System.Diagnostics;

namespace WorkWithNumber2Part
{
    public class GCD
    {
        #region EuclideanAlgorithm
        public static (int, int) EuclideanAlgorithmReturnTime(params int[] array)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = EuclideanAlgorithm(array);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return (result, ts.Milliseconds);
        }

        public static int EuclideanAlgorithm(params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array) + " can't be null");

            if (array.Length <= 1)
                throw new ArgumentException(nameof(array) + " count of numbers must be more than 1");
            int gcd = array[0];
            for (int i = 1; i < array.Length - 1; i++)
                gcd = EuclideanAlgorithm(gcd, array[i]);
            return gcd;
        }

        public static int EuclideanAlgorithm(int a, int b)
        {
            if (a < 0)
                a = a * -1;
            if (b < 0)
                b = b * -1;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }
        #endregion

        #region BynaryAlgorithm
        public static (int, int) BynaryAlgorithmReturnTime(params int[] array)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = BynaryAlgorithm(array);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return (result, ts.Milliseconds);
        }

        

        public static int BynaryAlgorithm(params int[] array)
        {

            if (array == null)
                throw new ArgumentNullException(nameof(array) + " can't be null");

            if (array.Length <= 1)
                throw new ArgumentException(nameof(array) + " count of numbers must be more than 1");
            int gcd = array[0];
            for (int i = 1; i < array.Length - 1; i++)
                gcd = EuclideanAlgorithm(gcd, array[i]);
            return gcd;
        }

        

        public static int BynaryAlgorithm(int a, int b)
        {
            if (a < 0)
                a = a * -1;
            if (b < 0)
                b = b * -1;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return BynaryAlgorithm(a >> 1, b);
                else
                    return BynaryAlgorithm(a >> 1, b >> 1) << 1;
            }
            if ((~b & 1) != 0)
                return BynaryAlgorithm(a, b >> 1);
            if (a > b)
                return BynaryAlgorithm((a - b) >> 1, b);
            return BynaryAlgorithm((b - a) >> 1, a);
        }

        #endregion
    }
}
