using System;

namespace ADS.DataStructures
{
    public class CircularList<T> : IList<T>
    {
        ListNode<T> head = null;
        ListNode<T> tail = null;

        public T First()
        {
            if (head == null)
                throw new IndexOutOfRangeException("The list is empty!");
            return head.data;
        }

        public T Last()
        {
            if (tail == null)
                throw new IndexOutOfRangeException("The list is empty!");
            return tail.data;
        }

        public T ElementAt(int pos)
        {
            if (head == null || pos < 0)
                throw new IndexOutOfRangeException("Index out of range!");

            ListNode<T> node = head;
            while (pos > 0)
            {
                node = node.next;
                pos--;
                if (node == head)
                    throw new IndexOutOfRangeException("Index out of range!");
            }

            return node.data;
        }

        public void Purge()
        {
            head = tail = null;
        }

        public void Append(T elem)
        {
            if (tail == null)
            {
                head = new ListNode<T>();
                head.data = elem;
                head.next = head;
                tail = head;
            }
            else
            {
                ListNode<T> node = new ListNode<T>();
                node.data = elem;
                node.next = head;
                tail.next = node;
                tail = node;
            }
        }

        public void Prepend(T elem)
        {
            if (head == null)
            {
                head = new ListNode<T>();
                head.data = elem;
                head.next = null;
                tail = head;
            }
            else
            {
                ListNode<T> node = new ListNode<T>();
                node.data = elem;
                node.next = head;
                head = node;
            }
        }

        public void InsertAfter(T elem, T after)
        {
            ListNode<T> node = head;

            while (node != null && !node.data.Equals(after))
                node = node.next;

            if (node == null)
                return;

            ListNode<T> insNode = new ListNode<T>();
            insNode.data = elem;
            insNode.next = node.next;

            node.next = insNode;
        }

        public void Remove(T elem)
        {
            ListNode<T> node = head;

            while (node != null && !node.data.Equals(elem))
            {
                node = node.next;
            }
        }

        public int Count()
        {
            int n = 0;
            for (ListNode<T> node = head;
                  node.next != head;
                  node = node.next, n++) ;

            return n;
        }

        public void Print()
        {
            ListNode<T> node = head;

            while (node.next != head)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }
    }
}
