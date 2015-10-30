using System;

namespace ADS.DataStructures
{
    public class StackAsVector<T>
    {
        const int MAX_SIZE = 100;

        T[] elems = new T[MAX_SIZE];

        int top = 0;


        public void Push( T x )
        {
            if (top == MAX_SIZE)
            {
                throw new OutOfMemoryException("Stack is full!");
            }

            elems[top++] = x;
        }

        public T Pop()
        {
            return elems[--top];
        }

        public T Peek()
        {
            return elems[top - 1];
        }

        public void Purge()
        {
            top = 0;
            // and if the stack consists of object references,
            // we may want also set them all to null: 
            // while ( top > 0 )
            //      elems[--top] = null;
        }

        public bool IsEmpty()
        {
            return top == 0;
        }
    }
}
