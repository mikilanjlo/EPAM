using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayLibrary
{
    public static class MatrixExtension
    {
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> a, SquareMatrix<T> b)
        {
            int rows = a.Rows > b.Rows ? a.Rows : b.Rows;
            int columns = a.Columns > b.Columns ? a.Columns : b.Columns;
            SquareMatrix<T> array = new SquareMatrix<T>(rows, columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    array[i, j] = a[i, j];
                }
            }
            for (int i = 0; i < b.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    array[i, j] += b[i, j] as dynamic;
                }
            }
            return array;
        }

        public static DiogonalMatrix<T> Sum<T>(this DiogonalMatrix<T> a, DiogonalMatrix<T> b)
        {
            return (DiogonalMatrix<T>)((SquareMatrix<T>)a).Sum<T>(b);
        }

        public static TransporyMatrix<T> Sum<T>(this TransporyMatrix<T> a, TransporyMatrix<T> b)
        {
            return (TransporyMatrix<T>)((SquareMatrix<T>)a).Sum<T>(b);
        }
    }
}
