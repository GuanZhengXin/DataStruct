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
            this.LinkNode = new SingleLinkNode<T>();
        }

        public bool IsEmpty()
        {
            return this.LinkNode.IsEmpty();
        }

        public T Peek()
        {
            return this.LinkNode.GetLast();
        }

        public T Pop()
        {
            return this.LinkNode.DeleteLast();
        }

        public void Push(T value)
        {
            this.LinkNode.AddLast(value);
        }
    }
}
