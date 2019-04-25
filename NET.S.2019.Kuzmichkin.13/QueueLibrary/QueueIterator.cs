using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QueueLibrary
{
    public class QueueIterator<T> : IEnumerator<T>
    {
        public T Current => CurrentNode.Data;

        private Node<T> head;
        private Node<T> CurrentNode;

        object IEnumerator.Current => CurrentNode.Data;

        public QueueIterator(Node<T> node)
        {
            CurrentNode = node ?? throw new ArgumentNullException();
            head = CurrentNode;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if(CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            CurrentNode = head;
        }
    }
}
