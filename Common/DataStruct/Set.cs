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
            this.Data = new BinarySearchTree<T>();
        }

        public void Add(T value)
        {
            this.Data.Add(value);
        }

        public int GetSize()
        {
            return this.Data.GetSize();
        }

        public bool IsEmpty()
        {
            return this.Data.IsEmpty();
        }

        public bool IsContains(T value)
        {
            return this.Data.IsContains(value);
        }

        public void Delete(T value)
        {
            this.Data.Delete(value);
        }
    }

    public class LinkNodeSet<T> : ISet<T>
    {
        private SingleLinkNode<T> Data;
        public LinkNodeSet()
        {
            this.Data = new SingleLinkNode<T>();
        }

        public void Add(T value)
        {
            if (!IsContains(value))
                this.Data.AddFirst(value);
        }

        public void Delete(T value)
        {
            this.Data.Delete(value);
        }

        public int GetSize()
        {
            return this.Data.GetSize();
        }

        public bool IsContains(T value)
        {
            return this.Data.IsContains(value);
        }

        public bool IsEmpty()
        {
            return this.Data.IsEmpty();
        }
    }
}
