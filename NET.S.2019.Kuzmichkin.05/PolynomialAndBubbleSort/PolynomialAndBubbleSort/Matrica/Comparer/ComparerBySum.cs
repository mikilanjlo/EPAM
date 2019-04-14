using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialAndBubbleSort.Matrix.Comparer
{
    class ComparerIntArrayBySum : IComparer<int[]>
    {       
        public int Compare(int[] x, int[] y)
        {
            if (x.Sum() > y.Sum())
                return 1;
            else if (x.Sum() < y.Sum())
                return -1;
            else
                return 0;
        }      
    }
}
