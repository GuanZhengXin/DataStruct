using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 二叉堆
    /// </summary>
    public class Heap<T> where T :IComparable
    {
        private Array<T> Data;
        private int Size => this.GetSize();

        public Heap(int capacity=20)
        {
            this.Data = new Array<T>();
        }

        public Heap(T[] arr)
        {
            Data = new Array<T>(arr);
            for (int i = GetParent(arr.Length-1); i >=0 ; i--)
            {
                SiftDown(i);
            }
        }

        public T GetMax()
        {
            return this.Data.Get(0);
        }

        public void Add(T value)
        {
            Data.AddLast(value);
            SiftUp(Data.GetSize()-1);
        }

        //漂浮比较
        private void SiftUp(int index)
        {
            while (index>0 && Data.Get(GetParent(index)).CompareTo(Data.Get(index))<0)
            {
                Data.Swap(GetParent(index), index);
                index = GetParent(index);
            }
        }

        public T ExecuteMax()
        {
            var res = Data.Get(0);
            Data.Swap(0, Data.GetSize() - 1);
            Data.Delete(Data.GetSize() - 1);
            SiftDown(0);
            return res;
        }

        private void SiftDown(int index)
        {
            while ( GetLeft(index)<Data.GetSize())
            {
                int nodeIndex = GetLeft(index);
                if (nodeIndex + 1 < Data.GetSize() && Data.Get(nodeIndex + 1).CompareTo(Data.Get(nodeIndex)) > 0)
                    nodeIndex = GetRight(index);
                if (Data.Get(index).CompareTo(Data.Get(nodeIndex)) >= 0)
                    break;
                Data.Swap(index, nodeIndex);
            }
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public bool IsContains(T value)
        {
            return this.Data.IsContain(value);
        }

        private int GetParent(int index)
        {
            if (index <= 0)
                return -1;
            return (index - 1) / 2;
        }

        private int GetLeft(int index)
        {
            return index * 2 + 1;
        }

        private int GetRight(int index)
        {
            return index * 2 + 2;
        }

        public int GetSize()
        {
            return this.Data.GetSize();
        }
    }
}
