using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 二分搜索树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable
    {
        public Node Root { get; set; }
        private int Size;
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }
            public Node(T value,Node left=null,Node right=null)
            {
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }
        }

        public int GetSize()
        {
            return this.Size;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Add(T value)
        {
            Root = AddNode(Root, value);
        }

        private Node AddNode(Node node, T value)
        {
            if (node == null)
                return new Node(value);

            if (node.Value.CompareTo(value) > 0)
                node.Left = AddNode(node.Left, value);
            else
                node.Right = AddNode(node.Right, value);
            return node;
        }

        public bool IsContains(T value)
        {
            return Contains(Root, value);
        }

        private bool Contains(Node node, T value)
        {
            if (node == null)
                return false;
            if (node.Value.CompareTo(value) > 0)
                return Contains(node.Left, value);
            else if(node.Value.CompareTo(value)<0)
                return Contains(node.Right, value);
            return true;
        }
    }
}
