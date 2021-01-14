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
        T DeQueue();
        T Peek();
    }

    public class Queue<T> : IQueue<T>
    {
        private Array<T> Data;
        public Queue(int capacity=20)
        {
            Data = new Array<T>(capacity);
        }

        public T DeQueue()
        {
            return Data.Delete(0);
        }

        public void EnQueue(T value)
        {
            Data.Add(value);
        }

        public int GetSize()
        {
            return Data.GetSize();
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }

        public T Peek()
        {
            return Data.Search(0);
        }
    }
}
