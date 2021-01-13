using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 优先队列  此处是由大顶堆实现的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProperityQueue<T> : IQueue<T> where T :IComparable
    {
        private MaxHeap<T> Data;
        private int Size => this.GetSize();

        public ProperityQueue()
        {
            this.Data = new MaxHeap<T>();
        }

        public T DeQueue()
        {
            return this.Data.ExecuteMax();
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
            return this.Data.IsEmpty();
        }

        public T Peek()
        {
            return this.Data.GetMax();
        }
    }
}
