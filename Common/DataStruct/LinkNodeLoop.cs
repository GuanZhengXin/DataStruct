using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataStruct
{
    /// <summary>
    /// 闭环链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkNodeLoop<T>
    {
        private Node DummyHead { get; set; }
        private int Size { get; set; }
        public LinkNodeLoop()
        {
            this.DummyHead = new Node();
            this.Size = 0;
        }

        public class Node
        {
            public Node()
            {
            }

            public Node(T value, Node node = null)
            {
                Value = value;
                Next = node;
            }

            public override string ToString()
            {
                return Value.ToString();
            }

            public T Value { get; set; }
            public Node Next { get; set; }
        }

        public void Add(T value)
        {
            var nextNode = DummyHead.Next;
            if (nextNode == null)
            {
                var node = new Node(value);
                DummyHead.Next = node;
                node.Next = DummyHead;
            }
            else
            {
                while (nextNode.Next != DummyHead)
                {
                    nextNode = nextNode.Next;
                }
                var node = new Node(value);
                node.Next = DummyHead;
                nextNode.Next = node;
            }
        }

        public override string ToString()
        {
            var build = new StringBuilder();
            var currentNode = DummyHead.Next;
            while (currentNode != DummyHead)
            {
                build.Append(currentNode + "->");
                currentNode = currentNode.Next;
            }
            build.Append("头");
            return build.ToString();
        }

    }
}
