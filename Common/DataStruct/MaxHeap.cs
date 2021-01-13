using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 大顶堆
    /// </summary>
    public class MaxHeap<T> where T : IComparable
    {
        private Array<T> Data;
        private int Size => this.GetSize();

        public MaxHeap(int capacity = 20)
        {
            this.Data = new Array<T>(capacity);
        }

        public MaxHeap(T[] arr)
        {
            Data = new Array<T>(arr);
            for (int i = GetParent(arr.Length - 1); i >= 0; i--)
            {
                ShiftDown(i);
            }
        }

        public T GetMax()
        {
            return this.Data.Get(0);
        }

        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Data.AddLast(value);
            SiftUp(Data.GetSize() - 1);
        }

        /// <summary>
        /// 漂浮比较
        /// </summary>
        /// <param name="index"></param>
        private void SiftUp(int index)
        {
            while (index > 0 && Data.Get(GetParent(index)).CompareTo(Data.Get(index)) < 0)
            {
                Data.Swap(GetParent(index), index);
                index = GetParent(index);
            }
        }

        /// <summary>
        /// 删除顶部元素
        /// </summary>
        /// <returns></returns>
        public T ExecuteMax()
        {
            var res = Data.Get(0);
            Data.Swap(0, Data.GetSize() - 1);
            Data.Delete(Data.GetSize() - 1);
            ShiftDown(0);
            return res;
        }

        private void ShiftDown(int index, int? maxIndex = default)
        {
            maxIndex = maxIndex ?? GetSize();
            while (GetLeft(index) < maxIndex)
            {
                int nodeIndex = GetLeft(index);
                if (nodeIndex + 1 < maxIndex && Data.Get(nodeIndex + 1).CompareTo(Data.Get(nodeIndex)) > 0)
                    nodeIndex = GetRight(index);

                if (Data.Get(index).CompareTo(Data.Get(nodeIndex)) >= 0)
                    break;

                Data.Swap(index, nodeIndex);
                index = nodeIndex;
            }
        }

        /// <summary>
        /// 堆是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsContains(T value)
        {
            return this.Data.IsContain(value);
        }

        /// <summary>
        /// 得到父亲节点的索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetParent(int index)
        {
            if (index <= 0)
                return -1;

            return (index - 1) / 2;
        }

        /// <summary>
        /// 得到左索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetLeft(int index)
        {
            return index * 2 + 1;
        }

        /// <summary>
        /// 得到右索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetRight(int index)
        {
            return index * 2 + 2;
        }

        /// <summary>
        /// 得到总元素个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return this.Data.GetSize();
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        /// <returns></returns>
        public Array<T> Sort()
        {
            var size = GetSize();
            while (size > 1)
            {
                Data.Swap(0, size - 1);
                ShiftDown(0, size - 1);
                var sb = new StringBuilder();
                for (int x = 0; x < Data.GetSize(); x++)
                {
                    sb.Append($"{Data.Get(x)},");
                }
                Console.WriteLine($"索引:{size - 1}" + " " + sb.ToString());
                size--;
            }

            return Data;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < GetSize(); i++)
            {
                sb.Append($"{Data.Get(i)},");
            }
            return sb.ToString();
        }
    }
}
