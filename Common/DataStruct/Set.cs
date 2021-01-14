using System;
using System.Collections.Generic;
using System.Text;
using Common.LinkNode;
using Common.Tree;

namespace Common
{
    public interface ISet<T>
    {
        bool IsContains(T value);
        int GetSize();
        bool IsEmpty();
        void Add(T value);
        void Delete(T value);
    }

    public class BinaryTreeSet<T> : ISet<T> where T: IComparable
    {
        private BinarySearchTree<T> Data;
        public BinaryTreeSet()
        {
            Data = new BinarySearchTree<T>();
        }

        public void Add(T value)
        {
            if (IsContains(value))
                return;

            Data.Add(value);
        }

        public int GetSize()
        {
            return Data.GetSize();
        }

        public bool IsEmpty()
        {
            return Data.IsEmpty();
        }

        public bool IsContains(T value)
        {
            return Data.IsContains(value);
        }

        public void Delete(T value)
        {
            Data.Delete(value);
        }
    }

    public class LinkNodeSet<T> : ISet<T>
    {
        private SingleLinkNode<T> Data;
        public LinkNodeSet()
        {
            Data = new SingleLinkNode<T>();
        }

        public void Add(T value)
        {
            if (IsContains(value))
                return;

            Data.AddFirst(value);
        }

        public void Delete(T value)
        {
            Data.Delete(value);
        }

        public int GetSize()
        {
            return Data.GetSize();
        }

        public bool IsContains(T value)
        {
            return Data.IsContains(value);
        }

        public bool IsEmpty()
        {
            return Data.IsEmpty();
        }
    }
}
