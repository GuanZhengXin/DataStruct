using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 基于数组的队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T>
    {
        int GetSize();
        bool IsEmpty();
        void EnQueue(T value);
        void DeQueue();
        T Peek();
    }

    public class Queue<T> : IQueue<T>
    {
        private Array<T> Data;
        public Queue(int capacity)
        {
            this.Data = new Array<T>(capacity);
        }

        public void DeQueue()
        {
            this.Data.Delete(0);
        }

        public void EnQueue(T value)
        {
            this.Data.Add(value);
        }

        public int GetSize()
        {
            return this.Data.GetSize();
        }

        public bool IsEmpty()
        {
            return this.GetSize() == 0;
        }

        public T Peek()
        {
            return this.Data.Search(0);
        }
    }
}
