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

            public Node(T value = default, Node next = default)
            {
                Value = value;
                Next = next;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public LinkNode()
        {
            DummyHead = new Node();
            Size = 0;
        }

        private Node DummyHead { get; set; }
        private int Size { get; set; }

        public void Add(int index, T value)
        {
            if (index < 0 || index > Size)
                throw new Exception("index is illegal");

            var node = new Node(value);
            var prev = DummyHead;
            for (int i = 0; i < index; i++)
                prev = prev.Next;

            node.Next = prev.Next;
            prev.Next = node;
            Size++;
        }

        public void AddLast(T value)
        {
            Add(Size, value);
        }

        public void AddFirst(T value)
        {
            Add(0, value);
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

        public void Delete(T value)
        {
            this.DummyHead.Next = DeleteValue(DummyHead.Next, value)
;
        }

        /// <summary>
        /// 反转链表
        /// </summary>
        public void Reverse()
        {
            var dict = new Dictionary<int, T>();
            var count = 0;
            var currentNode = DummyHead.Next;
            while (currentNode != null)
            {
                count++;
                dict.Add(count, currentNode.Value);
                currentNode = currentNode.Next;
            }

            var newDummyHead = new Node();
            DummyHead = newDummyHead;
            Size = 0;
            for (int i = count; i > 0; i--)
            {
                AddLast(dict[i]);
            }
        }

        private Node DeleteValue(Node node, T value)
        {
            if (node == null)
                return null;

            node.Next = DeleteValue(node.Next, value);
            return node.Value.Equals(value) ? node.Next : node;
        }

        public T DeleteFirst()
        {
            return this.Delete(0);
        }

        public T DeleteLast()
        {
            return this.Delete(this.Size - 1);
        }

        public int GetSize()
        {
            return this.Size;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
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
