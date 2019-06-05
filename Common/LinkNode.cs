using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkNode<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value=default, Node next=default)
            {
                this.Value = value;
                this.Next = next;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public LinkNode()
        {
            this.DummyHead = new Node();
            this.Size = 0;
        }

        private Node DummyHead { get; set; }
        private int Size { get; set; }

        public void Add(int index,T value)
        {
            if (index < 0 || index > this.Size)
                throw new Exception("index is illegal");
            var node = new Node(value);
            var prev = DummyHead;
            for (int i = 0; i < index; i++)
                prev = prev.Next;
            node.Next = prev.Next;
            prev.Next = node;
            this.Size++;
        }

        public void AddLast(T value)
        {
            this.Add(this.Size,value);
        }

        public void AddFirst(T value)
        {
            this.Add(0, value);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= this.Size)
                throw new Exception("index is illegal");
            var currentNode = DummyHead.Next;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;
        }

        public T GetLast()
        {
            return this.Get(this.Size - 1);
        }

        public void Update(int index, T value)
        {
            if (index < 0 || index >= this.Size)
                throw new Exception("index is illegal");
            var currentNode = DummyHead.Next;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Value = value;
        }

        public bool IsContains(T value)
        {
            var currentNode = DummyHead.Next;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                    return true;
                currentNode = currentNode.Next;
            }
            return false;
        }

        public T Delete(int index)
        {
            if (index < 0 || index >= this.Size)
                throw new Exception("index is illegal");
            var prevNode = this.DummyHead;
            for (int i = 0; i < index; i++)
            {
                prevNode = prevNode.Next;
            }
            var delNode = prevNode.Next;
            prevNode.Next = delNode.Next;
            delNode.Next = null;
            this.Size--;
            return delNode.Value;
        }

        public T DeleteFirst()
        {
            return this.Delete(0);
        }

        public T  DeleteLast()
        {
            return this.Delete(this.Size-1);
        }

        public int GetSize()
        {
            return this.Size;
        }

        public bool IsEmpty()
        {
            return this.Size==0;
        }

        public override string ToString()
        {
            var build = new StringBuilder();
            var currentNode = DummyHead.Next;
            while (currentNode != null)
            {
                build.Append(currentNode + "->");
                currentNode = currentNode.Next;
            }
            build.Append("Null");
            return build.ToString();
        }
    }
}
