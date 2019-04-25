using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayLibrary
{
    public class TransporyMatrix<T> : SquareMatrix<T>
    {
        public TransporyMatrix(int rows, int columns) : base(rows, columns) { }

        public override void Add(T element, int i, int j)
        {
            if (i < 0 || i >= Rows)
                throw new IndexOutOfRangeException();
            if (j < 0 || j >= Columns)
                throw new IndexOutOfRangeException();
            Array[i , j] = element;
            Array[j , i] = element;
        }
    }
}
