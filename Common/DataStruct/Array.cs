using System;
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
        public bool IsFull => this.Capacity == this.Size;
        public Array(int capacity = 20)
        {
            this.Capacity = capacity;
            this.Data = new T[this.Capacity];
        }

        public Array(T[] arr)
        {
            Data = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                this.Data[i] = arr[i];
            }
            Size = arr.Length;
        }

        public int GetSize()
        {
            return this.Size;
        }

        public void Add(T value)
        {
            if (IsFull)
                this.ExpandCapacity(this.Capacity * 2);
            this.Size++;
            this.Data[this.Size - 1] = value;
        }

        public void AddLast(T value)
        {
            this.Insert(GetSize(), value);
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
            for (int i = 0; i < this.Data.Length; i++)
            {
                newData[i] = this.Data[i];
            }
            this.Data = newData;
            this.Capacity = capacity;
        }

        public void Insert(int index,T value)
        {
            if (index < 0)
                throw new Exception("index is less than zero");

            if (index > this.Capacity-1 || index > this.Size)
                throw new Exception("index is more than capacity or Size");

            for (int i = Size-1; i >index-1; i--)
            {
                this.Data[i + 1] = this.Data[i];
            }
            this.Data[index] = value;
            this.Size++;
        }

        public void SetEmpty()
        {
            this.Data = new T[this.Capacity];
            this.Size = default;
        }

        public T Delete(int index)
        {
            if (index < 0)
                throw new Exception("index is less than zero");

            if (index > this.Capacity-1)
                throw new Exception("index is more than capacity");

            if (index > this.Size-1)
                return default;

            var value = this.Data[index];
            for (int i = index; i < this.Size-1; i++)
            {
                this.Data[i] = this.Data[i+1];
            }
            this.SetEmpty(this.Size-1);
            this.Size--;
            if (this.Size <= this.Capacity/4)
               this.NarrowCapacity(this.Capacity / 2);
            return value;
        }

        private void NarrowCapacity(int capacity)
        {
            var newData = new T[capacity];
            for (int i = 0; i < newData.Length; i++)
            {
                newData[i] = this.Data[i];
            }
            this.Data = newData;
            this.Capacity = capacity;
        }

        private void SetEmpty(int index)
        {
            this.Data[index] = default;
        }

        public void DeleteElement(T value)
        {
            var eleIndex = -1;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Data[i].Equals(value))
                    eleIndex = i;
            }
            if (eleIndex < 0)
                return;
            this.Delete(eleIndex);
        }

        public void Update(int index,T value)
        {
            if (index < 0)
                throw new Exception("index is less than zero");

            if (index > this.Capacity - 1)
                throw new Exception("index is more than capacity");

            if (index > this.Size - 1)
                return;

            this.Data[index] = value;
        }

        public bool IsContain(T value)
        {
            var isContain = false;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Data[i].Equals(value))
                    isContain = true;
            }
            return isContain;
        }

        public int Find(T value)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Data[i].Equals(value))
                    return i;
            }
            return -1;
        }

        public T Search(int index)
        {
            if(index>Size-1 || index<0)
                throw new Exception("this index is empty or index is less than zero");
            return this.Data[index];
        }

        public override string ToString()
        {
            var list = new List<T>();
            for (int i = 0; i < this.Size; i++)
            {
                list.Add(this.Data[i]);
            }
            return $"Use {this.Size}, Capacity {this.Capacity} Numbers is {string.Join(",", list.Select(i => i))}";
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }
    }
}
