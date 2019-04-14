using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialAndBubbleSort
{
    public  class ComparerByMaxElement: IComparer<int[]>
    {
        public  int Compare(int[] x, int[] y)
        {
            if (x.Max() > y.Max())
                return 1;
            else if (x.Max() < y.Max())
                return -1;
            else
                return 0;
        }
    }
}
