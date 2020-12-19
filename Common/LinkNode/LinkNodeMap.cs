using System;
using System.Collections.Generic;
using System.Text;

namespace Common.LinkNode
{
    public class LinkNodeMap<K, V> : IMap<K,V>
    {
        private class Node
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Node Next { get; set; }
            public Node(K key=default,V value=default,Node node=null)
            {
                this.Key = key;
                this.Value = value;
                this.Next = node;
            }
        }

        private Node DummyHead;
        private int Size;
        public LinkNodeMap()
        {
            DummyHead = new Node();
        }

        public void Add(K key, V value)
        {
            DummyHead.Next = new Node(key, value, DummyHead.Next);
            Size++;
        }

        public void Delete(K key)
        {
            var preNode = DummyHead;
            while (preNode.Next != null)
            {
                if (preNode.Next.Key.Equals(key))
                    break;
                preNode = preNode.Next;
            }
            if (preNode.Next != null)
            {
                var delNode = preNode.Next;
                preNode.Next = delNode.Next;
                delNode.Next = null;
                this.Size--;
            }
        }

        public int GetSize()
        {
            return this.Size;
        }

        private Node Find(K key)
        {
            var currentNode = DummyHead.Next;
            while (currentNode != null)
            {
                if (currentNode.Key.Equals(key))
                    return currentNode;
                currentNode = currentNode.Next;
            }
            return null;
        }

        public bool IsContains(K key)
        {
            var node = this.Find(key);
            return node != null;
        }

        public void Set(K key, V value)
        {
            var node = this.Find(key);
            if (node == null)
                return;
            node.Value = value;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }
    }
}
