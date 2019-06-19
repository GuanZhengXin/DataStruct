using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    class BinarySearchTreeMap<K, V> : IMap<K, V> where K: IComparable
    {
        private class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public K Key { get; set; }
            public V Value { get; set; }

            public Node( K key=default, V value=default, Node left=null, Node right=null)
            {
                Left = left;
                Right = right;
                Key = key;
                Value = value;
            }
        }

        private Node Root;
        private int Size;

        public void Add(K key, V value)
        {
            Root = Add(Root, key, value);
        }

        private Node Add(Node node, K key, V value)
        {
            if (node == null)
            {
                Size++;
                return new Node(key, value);
            }
            if (node.Key.CompareTo(key) > 0)
                node.Left = FindNode(node.Left, key);
            else if (node.Key.CompareTo(key) < 0)
                node.Left =  FindNode(node.Right, key);

            return node;
        }

        public void Delete(K key)
        {
            var node = FindNode(Root,key);
            if(node!=null)
                Root = Delete(Root, key);
        }

        private Node FindMinNode(Node node)
        {
            if (node.Left == null)
                return node;
            return FindMinNode(node.Left);
        }

        private Node DeleteMinNode(Node node)
        {
            if (node.Left == null)
            {
                var rightNode = node.Right;
                node.Right = null;
                Size--;
                return rightNode;
            }
            node.Left = DeleteMinNode(node.Left);
            return node;
        }

        private Node Delete(Node node, K key)
        {
            if (node == null)
                return null;
            if (node.Key.CompareTo(key) > 0)
            {
                node.Left = Delete(node.Left, key);
                return node;
            }
            else if (node.Key.CompareTo(key) < 0)
            {
                node.Right = Delete(node.Right, key);
                return node;
            }
            else
            {
                if (node.Left == null)
                {
                    var rightNode = node.Right;
                    node.Right = null;
                    Size--;
                    return rightNode;
                }
                if (node.Right == null)
                {
                    var leftNode = node.Left;
                    node.Left = null;
                    Size--;
                    return leftNode;
                }
                // 左右子树都不为空
                var successor = FindMinNode(node.Right);
                successor.Right = DeleteMinNode(node.Right);
                successor.Left = node.Left;
                node.Left = node.Right = null;
                return successor;
            }
        }

        public int GetSize()
        {
            return this.Size;
        }

        private Node FindNode(Node node,K key)
        {
            if (node == null)
                return null;
            if (node.Key.CompareTo(key) > 0)
                return FindNode(node.Left, key);
            else if (node.Key.CompareTo(key) < 0)
                return FindNode(node.Right, key);
            else
                return node;
        }

        public bool IsContains(K key)
        {
            var node = FindNode(Root,key);
            return node!=null;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Set(K key, V value)
        {
            var node = FindNode(Root, key);
            if (node == null)
                return;
            node.Value = value;
        }
    }
}
