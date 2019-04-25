using System;
using System.Collections.Generic;

namespace ArrayLibrary
{
    public class SquareMatrix<T>
    {

        private T[,] m_array;
        private int m_rows;
        private int m_columns;
        List<IndexEvents<T>> events = new List<IndexEvents<T>>();

        public SquareMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException();
            Rows = rows;
            Columns = columns;
            Array = new T[rows, columns];
        }

        public T this[int i, int j]
        {
            get
            {
                return m_array[i, j];
            }
            set
            {
                this.Add(value, i, j);
            }
        }

        public T[,] Array
        {
            get { return m_array; }
            set { m_array = value; }
        }

        public int Rows
        {
            get { return m_rows; }
            protected set { m_rows = value; }
        }

        public int Columns
        {
            get { return m_columns; }
            protected set { m_columns = value; }
        }

        

        public virtual void Add(T element,int i, int j)
        {
            if (i < 0 || i >= Rows)
                throw new IndexOutOfRangeException();
            if (j < 0 || j >= Columns)
                throw new IndexOutOfRangeException();
            Array[i, j] = element;
        }

        public void SubscribeOnChange(IndexEvents<T>.IndexsChange ev, int i, int j)
        {
            for (int k= 0; k < events.Count; k++)
                if (events[k].Subscribe(ev, i, j))
                    return;
            events.Add(new IndexEvents<T>(i, j));
            events[events.Count].Subscribe(ev, i, j);
        }
    }
}
