using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialAndBubbleSort
{
    class ComparerBySum : IComparer<int[]>
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
