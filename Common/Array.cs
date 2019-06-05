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
            if (this.Size <= this.Capacity)
                this.ExpandCapacity(this.Capacity / 2);
            return value;
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

        public bool IsContain(int value)
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
    }
}
