﻿using System;
using System.Text;

namespace Common
{
    /// <summary>
    /// 小顶堆
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> where T: IComparable
    {
        private Array<T> Data { get; set; }
        public MinHeap(int capacity=20)
        {
            Data = new Array<T>(capacity);
        }

        /// <summary>
        /// 添加一个元素
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Data.AddLast(value);
            ShiftUp(GetSize() - 1);
        }

        /// <summary>
        /// 得到某个索引的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            return Data.Get(index);
        }

        /// <summary>
        /// 得到元素总个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Data.GetSize();
        }

        /// <summary>
        /// 删除堆顶元素
        /// </summary>
        public void DeleteHeapTop()
        {
            Data.Swap(0,GetSize() - 1);
            Data.Delete(GetSize() - 1);
            ShiftDown(0);
        }

        /// <summary>
        /// 向下漂移比较
        /// </summary>
        /// <param name="index"></param>
        private void ShiftDown(int index)
        {
            while (GetLeft(index) < GetSize())
            {
                var currrentIndex = GetLeft(index);
                if (currrentIndex + 1 < GetSize() && Get(currrentIndex).CompareTo(currrentIndex + 1) > 0)
                    currrentIndex += 1;

                if (Get(currrentIndex).CompareTo(Get(index)) >= 0)
                    break;

                Data.Swap(currrentIndex, index);
            }
        }

        /// <summary>
        /// 向上漂移比较
        /// </summary>
        /// <param name="index"></param>
        private void ShiftUp(int index)
        {
            while (index > 0 && Get(GetParent(index)).CompareTo(Get(index)) > 0)
            {
                Data.Swap(index, GetParent(index));
                index = GetParent(index);
            }
        }

        /// <summary>
        /// 得到元素的父亲节点索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetParent(int index)
        {
            if (index <= 0)
                return -1;

            return (index -1) / 2;
        }

        /// <summary>
        /// 得到元素的左边索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetLeft(int index)
        {
            return index * 2 + 1;
        }

        /// <summary>
        /// 得到元素的右边索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetRight(int index)
        {
            return index * 2 + 2;
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
