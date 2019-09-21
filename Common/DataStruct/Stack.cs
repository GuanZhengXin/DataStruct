using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStack<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        bool IsEmpty();
        void Clear();
    }

    public class Stack<T> : IStack<T>
    {
        private Array<T> Data;
        public Stack(int capacity=20)
        {
            this.Data = new Array<T>(capacity);
        }

        public void Clear()
        {
            this.Data.SetEmpty();
        }

        public bool IsEmpty()
        {
            return this.Data.GetSize() == 0;
        }

        public T Peek()
        {
            return this.Data.Search(this.Data.GetSize());
        }

        public T Pop()
        {
            return this.Data.Delete(this.Data.GetSize());
        }

        public void Push(T value)
        {
            this.Data.Add(value);
        }
    }
}
