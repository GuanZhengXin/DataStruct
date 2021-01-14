using System;
using System.Collections.Generic;
using System.Text;

namespace Common.LinkNode
{
    public class LinkNodeStack<T> : IStack<T>
    {
        private SingleLinkNode<T> LinkNode;
        public LinkNodeStack()
        {

        }

        public void Clear()
        {
            LinkNode = new SingleLinkNode<T>();
        }

        public bool IsEmpty()
        {
            return LinkNode.IsEmpty();
        }

        public T Peek()
        {
            return LinkNode.GetLast();
        }

        public T Pop()
        {
            return LinkNode.DeleteLast();
        }

        public void Push(T value)
        {
            LinkNode.AddLast(value);
        }
    }
}
