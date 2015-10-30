using System;

namespace ADS.DataStructures
{
    class StackAsList<T>
    {
        const int MAX_SIZE = 100;

        SingleLinkedList<T> list = new SingleLinkedList<T>();

        int top = 0;


        public void Push(T x)
        {
            if (top == MAX_SIZE)
            {
                throw new OutOfMemoryException( "Stack is full!" );
            }

            list.Prepend(x);
            top++;
        }

        public T Pop()
        {
            top--;
            T data = list.First();
            list.Remove(data);
            return data;
        }

        public T Peek()
        {
            return list.First();
        }

        public void Purge()
        {
            top = 0;
            list.Purge();
        }

        public bool IsEmpty()
        {
            return top == 0;
        }
    }
}
