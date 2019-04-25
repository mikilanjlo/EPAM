using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayLibrary
{
    public class DiogonalMatrix<T> : SquareMatrix<T>
    {
        public DiogonalMatrix(int rows, int columns) : base(rows, columns) { }

        public override void Add(T element, int i, int j)
        {
            if (i < 0 || i >= Rows)
                throw new IndexOutOfRangeException();
            if (j < 0 || j >= Columns)
                throw new IndexOutOfRangeException();
            if (i != j)
                throw new ArgumentException();
            Array[i, j] = element;
        }
    }
}
