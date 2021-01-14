using System;
using System.Collections.Generic;
using System.Text;

namespace Common.LinkNode
{
    public class LinkNodeQueue<T> : IQueue<T>
    {
        private class Node
        {
            public Node(T value = default, Node next=default)
            {
                Value = value;
                Next = next;
            }

            public T Value { get; set; }
            public Node Next { get; set; }

        }

        private int Size;
        private Node DummyHead;
        private Node Tail;

        public LinkNodeQueue()
        {
            DummyHead = new Node();
            Size = 0;
        }

        public int GetSize()
        {
            return Size;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void EnQueue(T value)
        {
            if (Tail == null)
            {
                Tail = new Node(value);
                DummyHead.Next = Tail;
            }
            else
            {
                Tail.Next = new Node(value);
                Tail = Tail.Next;
            }
            Size++;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                throw new Exception("queue is empty");
            var delNode = DummyHead.Next;
            DummyHead.Next = delNode.Next;
            delNode.Next = null;
            Size--;
            return delNode.Value;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("queue is empty");
            return DummyHead.Next.Value;
        }

        public override string ToString()
        {
            if (IsEmpty())
                return "queue is empty";
            var str = new StringBuilder();
            var node = DummyHead.Next;
            str.Append("Front ");
            while (node != null)
            {
                str.Append(node.Value + "-> ");
                node = node.Next;
            }
            str.Append("Tail");
            return str.ToString();
        }

    }
}
