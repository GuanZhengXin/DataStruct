using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 循环队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoopQueue<T> : IQueue<T>
    {
        private T[] Data { get; set; }
        private int Size { get; set; }
        private int Front { get; set; }
        private int Tail { get; set; }
        public LoopQueue(int capacity=20)
        {
            Data = new T[capacity + 1];
        }

        public int GetCapacity()
        {
            return this.Data.Length - 1;
        }

        public void DeQueue()
        {
            Data[Front] = default;
            Front = (Front + 1) % this.Data.Length;
            if (this.Size == this.GetCapacity() / 4)
                this.ReSize(this.GetCapacity() / 2);
        }

        public void EnQueue(T value)
        {
            if ((Tail + 1) % this.Data.Length == Front)
                ReSize(this.GetCapacity() * 2 + 1);
            Data[Tail] = value;
            this.Tail = (this.Tail + 1) % this.Data.Length;
            this.Size++;
        }

        private void ReSize(int capacity)
        {
            var data = new T[capacity];
            for (int i = 0; i < Size; i++)
            {
                data[i] = this.Data[(i + Front) % this.Data.Length];
            }
            this.Data = data;
            Front = 0;
        }

        public int GetSize()
        {
            return this.Size;
        }

        public bool IsEmpty()
        {
            return this.Front == this.Tail;
        }

        public T Peek()
        {
            return this.Data[Front];
        }
    }
}
