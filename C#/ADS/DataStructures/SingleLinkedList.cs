using System;

namespace ADS.DataStructures
{
    public class ListNode<T>
    {
        public T data;
        public ListNode<T> next;
    }

    public class SingleLinkedList<T> : IList<T>
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
            if (pos < 0)
                throw new IndexOutOfRangeException("Index out of range!");

            ListNode<T> node = head;
            while (pos > 0)
            {
                if (node == null)
                    throw new IndexOutOfRangeException("Index out of range!");
                node = node.next;
                pos--;
            }

            return node.data;
        }

        public void Purge()
        {
            head = tail = null;
        }

        public void Append(T elem)
        {
            ListNode<T> node = new ListNode<T>();
            node.data = elem;
            node.next = null;

            if (head == null)
                head = node;
            else
                tail.next = node;

            tail = node;
        }

        public void Prepend(T elem)
        {
            ListNode<T> node = new ListNode<T>();
            node.data = elem;
            node.next = null;

            if (head == null)
                head = node;
            else
                node.next = head;

            head = node;
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

            if (node == tail)
                tail = insNode;
        }

        public void Remove(T elem)
        {
            ListNode<T> node = head;
            ListNode<T> prevnode = null;

            while (node != null && !node.data.Equals(elem))
            {
                prevnode = node;
                node = node.next;
            }

            if (node == null)
                return;

            if (node == head)
                head = node.next;
            else
                prevnode.next = node.next;
            if (node == tail)
                tail = prevnode;
        }


        /// <summary>
        /// Iterative list reverse
        /// </summary>
        public void Reverse()
        {
            ListNode<T> n = head;
            ListNode<T> next = null, prev = null;

            while (n != null)
            {
                next = n.next;
                n.next = prev;
                prev = n;
                n = next;
            }

            tail = head;
            head = prev;
        }

        /// <summary>
        /// Recursive list reverse
        /// </summary>
        public void ReverseR()
        {
            ReverseRecursive(head);
        }

        public void ReverseRecursive(ListNode<T> node)
        {
            if (node == null)
                return;

            if (node.next == null)
            {
                head = node;
                return;
            }

            ReverseRecursive(node.next);

            node.next.next = node;
            node.next = null;

            tail = node;
        }


        public int Count()
        {
            int n = 0;
            for (ListNode<T> node = head;
                  node != null;
                  node = node.next, n++) ;

            return n;
        }

        public void Print()
        {
            ListNode<T> node = head;

            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }
    }
}
