using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    /// <summary>
    /// 基础数组
    /// </summary>
    public class Array<T>
    {
        private T[] Data;
        private int Size;
        private int Capacity;
        public bool IsFull => Capacity == Size;
        public Array(int capacity = 20)
        {
            Capacity = capacity;
            Data = new T[Capacity];
        }

        public Array(T[] arr)
        {
            Data = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                Data[i] = arr[i];
            }
            Size = arr.Length;
        }

        public int GetSize()
        {
            return Size;
        }

        public void Add(T value)
        {
            if (IsFull)
                ExpandCapacity(Capacity * 2);
            Size++;
            Data[Size - 1] = value;
        }

        public void AddLast(T value)
        {
            Insert(GetSize(), value);
        }

        /// <summary>
        /// 交换数据
        /// </summary>
        /// <param name="i">索引i</param>
        /// <param name="j">索引j</param>
        public void Swap(int i, int j)
        {
            if(i<0 || i>=GetSize() || j<0 || j>=GetSize())
                throw new ApplicationException("index is overflow");

            var temp = Data[i];
            Data[i] = Data[j];
            Data[j] = temp;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= GetSize())
                throw new ApplicationException("index is overflow");

            return Data[index];
        }

        private void ExpandCapacity(int capacity)
        {
            var newData = new T[capacity];
            for (int i = 0; i < Data.Length; i++)
            {
                newData[i] = Data[i];
            }
            Data = newData;
            Capacity = capacity;
        }

        public void Insert(int index,T value)
        {
            if (index < 0)
                throw new Exception("index is less than zero");

            if (index > Capacity-1 || index > Size)
                throw new Exception("index is more than capacity or Size");

            for (int i = Size-1; i >index-1; i--)
            {
                Data[i + 1] = Data[i];
            }
            Data[index] = value;
            Size++;
        }

        public void SetEmpty()
        {
            Data = new T[Capacity];
            Size = default;
        }

        public T Delete(int index)
        {
            if (index < 0)
                throw new Exception("index is less than zero");

            if (index > Capacity-1)
                throw new Exception("index is more than capacity");

            if (index > Size-1)
                return default;

            var value = Data[index];
            for (int i = index; i < Size-1; i++)
            {
                Data[i] = Data[i+1];
            }
            SetEmpty(Size-1);
            Size--;
            if (Size <= Capacity/4)
               NarrowCapacity(Capacity / 2);

            return value;
        }

        private void NarrowCapacity(int capacity)
        {
            var newData = new T[capacity];
            for (int i = 0; i < newData.Length; i++)
            {
                newData[i] = Data[i];
            }
            Data = newData;
            Capacity = capacity;
        }

        private void SetEmpty(int index)
        {
            Data[index] = default;
        }

        public void DeleteElement(T value)
        {
            var eleIndex = -1;
            for (int i = 0; i < Size; i++)
            {
                if (Data[i].Equals(value))
                    eleIndex = i;
            }
            if (eleIndex < 0)
                return;
            Delete(eleIndex);
        }

        public void Update(int index,T value)
        {
            if (index < 0)
                throw new Exception("index is less than zero");

            if (index > Capacity - 1)
                throw new Exception("index is more than capacity");

            if (index > Size - 1)
                return;

            Data[index] = value;
        }

        public bool IsContain(T value)
        {
            var isContain = false;
            for (int i = 0; i < Size; i++)
            {
                if (Data[i].Equals(value))
                    isContain = true;
            }
            return isContain;
        }

        public int Find(T value)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Data[i].Equals(value))
                    return i;
            }
            return -1;
        }

        public T Search(int index)
        {
            if(index>Size-1 || index<0)
                throw new Exception("this index is empty or index is less than zero");
            return Data[index];
        }

        public override string ToString()
        {
            var list = new List<T>();
            for (int i = 0; i < Size; i++)
            {
                list.Add(Data[i]);
            }
            return $"Use {Size}, Capacity {Capacity} Numbers is {string.Join(",", list.Select(i => i))}";
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }
    }
}
