using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayLibrary
{
    public class IndexEvents<T>
    {
        public delegate void IndexsChange(T newElement);
        private int m_i;
        private int m_j;
        public event IndexsChange IndexsChangeEvent;

        public IndexEvents(int i,int j) { m_i = i; m_j = j; }
        public bool Subscribe(IndexsChange ev, int i, int j)
        {
            if (i == m_i && j == m_j)
            {
                IndexsChangeEvent += ev;
                return true;
            }
            return false;
        }

    }
}
