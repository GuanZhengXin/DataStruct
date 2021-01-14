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
            return Data.Length - 1;
        }

        public T DeQueue()
        {
            var type = Data[Front];
            Data[Front] = default;
            Front = (Front + 1) % Data.Length;
            if (Size == GetCapacity() / 4)
                ReSize(GetCapacity() / 2);
            return type;
        }

        public void EnQueue(T value)
        {
            if ((Tail + 1) % Data.Length == Front)
                ReSize(GetCapacity() * 2 + 1);
            Data[Tail] = value;
            Tail = (Tail + 1) % Data.Length;
            Size++;
        }

        private void ReSize(int capacity)
        {
            var data = new T[capacity];
            for (int i = 0; i < Size; i++)
            {
                data[i] = Data[(i + Front) % Data.Length];
            }
            Data = data;
            Front = 0;
        }

        public int GetSize()
        {
            return Size;
        }

        public bool IsEmpty()
        {
            return Front == Tail;
        }

        public T Peek()
        {
            return Data[Front];
        }
    }
}
