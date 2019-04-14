﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialAndBubbleSort.Matrix.Comparer
{
    public class ComparerByMinElement : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x.Min() > y.Min())
                return 1;
            else if (x.Min() < y.Min())
                return -1;
            else
                return 0;
        }
    }
}
