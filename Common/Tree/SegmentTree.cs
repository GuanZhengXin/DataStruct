using System;
using System.Text;

namespace Common.Tree
{
    public interface IMerger<T>
    {
        /// <summary>
        /// 自定义合并规则
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        T Merge(T t1, T t2);
    }

    /// <summary>
    /// 线段树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SegmentTree<T>
    {
        public SegmentTree(T[] datas, IMerger<T> merger)
        {
            Merger = merger;
            Data = datas;
            Tree = new T[datas.Length * 4];
            BuildTree(0, 0, datas.Length - 1);
        }

        private T[] Tree { get; set; }
        private T[] Data { get; set; }
        private readonly IMerger<T> Merger;

        /// <summary>
        /// 构建线段树
        /// </summary>
        /// <param name="treeIndex"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private void BuildTree(int treeIndex, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex)
            {
                Tree[treeIndex] = Data[leftIndex];
                return;
            }

            var leftTree = GetLeftIndex(treeIndex);
            var rightTree = GetRightIndex(treeIndex);

            var mid = leftIndex + (rightIndex - leftIndex) / 2;
            BuildTree(leftTree, leftIndex, mid);
            BuildTree(rightTree, mid + 1, rightIndex);
            Tree[treeIndex] = Merger.Merge(Tree[leftTree], Tree[rightTree]);
        }

        /// <summary>
        /// 得到值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            if (index < 0 || index > Tree.Length)
                return default;

            return Tree[index];
        }

        /// <summary>
        /// 区间查询
        /// </summary>
        /// <param name="queryLeftIndex"></param>
        /// <param name="queryRightIndex"></param>
        /// <returns></returns>
        public T Query(int queryLeftIndex, int queryRightIndex)
        {
            if (queryLeftIndex < 0 || queryRightIndex < 0 || queryRightIndex >= Data.Length || queryLeftIndex >= Data.Length)
                throw new ArgumentException("参数有误");

            return Query(0, 0, Data.Length - 1, queryLeftIndex, queryRightIndex);
        }

        /// <summary>
        /// 查询区间
        /// </summary>
        /// <param name="treeIndex">当前查询索引</param>
        /// <param name="l">总区间左索引</param>
        /// <param name="r">总区间右索引</param>
        /// <param name="queryLeftIndex">查询左索引</param>
        /// <param name="queryRightIndex">查询右索引</param>
        /// <returns></returns>
        private T Query(int treeIndex, int l, int r, int queryLeftIndex, int queryRightIndex)
        {
            if (l == queryLeftIndex && r == queryRightIndex)
                return Tree[treeIndex];

            var leftTreeIndex = GetLeftIndex(treeIndex);
            var rightTreeIndex = GetRightIndex(treeIndex);
            var mid = l + (r - l) / 2;
            if (queryLeftIndex >= mid + 1)
                return Query(rightTreeIndex, mid + 1, r, queryLeftIndex, queryRightIndex);
            else if (queryRightIndex <= mid)
                return Query(leftTreeIndex, l, mid, queryLeftIndex, queryRightIndex);

            var left = Query(leftTreeIndex, l, mid, queryLeftIndex, mid);
            var right = Query(rightTreeIndex, mid + 1, r, mid + 1, queryRightIndex);
            return Merger.Merge(left, right);
        }

        /// <summary>
        /// 跟新某个数据
        /// </summary>
        /// <param name="index">更新的索引</param>
        /// <param name="value">更新的数据</param>
        public void Update(int index, T value)
        {
            if (index < 0 || index >= Data.Length)
                throw new ArgumentException("参数有误");

            Data[index] = value;
            Update(0,0,Data.Length - 1, index , value);
        }

        /// <summary>
        /// 跟新某个数据
        /// </summary>
        /// <param name="treeIndex"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void Update(int treeIndex, int l, int r, int index, T value)
        {
            if (l == r)
            {
                Tree[treeIndex] = value;
                return;
            }

            var mid = l + (r - l) / 2;
            var leftTreeIndex = GetLeftIndex(treeIndex);
            var rightTreeIndex = GetRightIndex(treeIndex);
            if (index >= mid + 1)
                Update(rightTreeIndex, mid + 1, r, index, value);
            else if (index <= mid)
                Update(leftTreeIndex, l, mid, index, value);

            Tree[treeIndex] =  Merger.Merge(Tree[leftTreeIndex], Tree[rightTreeIndex]);
        }

        private int GetLeftIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightIndex(int index)
        {
            return index * 2 + 2;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Tree.Length; i++)
            {
                sb.Append($"{Tree[i]},");
            }
            return sb.ToString();
        }
    }
}
