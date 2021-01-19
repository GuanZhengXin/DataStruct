using System;
namespace Common.DataStruct
{
    /// <summary>
    /// 并查集 查询节点是否相连
    /// </summary>
    public class UnionFind
    {
        /// <summary>
        /// 索引为节点 值为节点指向的父节点的索引
        /// </summary>
        private int[] Parent { get; set; }

        /// <summary>
        /// 索引为节点 值为根节点的节点个数
        /// </summary>
        private int[] NumSize { get; set; }

        /// <summary>
        /// 索引为节点 值为根节点的排名参考
        /// </summary>
        private int[] Rank {get;set;}

        public UnionFind(int size)
        {
            Parent = new int[size];
            NumSize = new int[size];
            Rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                Parent[i] = i;
                NumSize[i] = 1;
                Rank[i] = 1;
            }
        }

        public int GetSize()
        {
            return Parent.Length;
        }

        /// <summary>
        /// 查找元素的跟节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Find(int p)
        {
            if (p < 0 || p >= Parent.Length)
                throw new ArgumentException("参数错误");

            while (p != Parent[p])
            {
                // 路经压缩
                Parent[p] = Parent[Parent[p]];
                p = Parent[p];
            }
            return p;
        }

        public bool IsConnected(int p,int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 合并两个元素
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void UnionOrigin(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);
            if (pRoot == qRoot)
                return;
            Parent[pRoot] = qRoot;
        }

        /// <summary>
        /// 合并两个元素
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void UnionBySize(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);
            if (pRoot == qRoot)
                return;

            if (NumSize[p] < NumSize[q])
            {
                Parent[pRoot] = qRoot;
                NumSize[qRoot] += NumSize[pRoot];
            }
            else
            {
                Parent[qRoot] = pRoot;
                NumSize[pRoot] += NumSize[qRoot];
            }
        }

        /// <summary>
        /// 合并两个元素
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void UnionByRank(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);
            if (pRoot == qRoot)
                return;

            if (Rank[pRoot] < Rank[qRoot])
                Parent[pRoot] = qRoot;
            else if (Rank[qRoot] > Rank[pRoot])
                Parent[qRoot] = pRoot;
            else
            {
                Parent[qRoot] = pRoot;
                Rank[pRoot]++;
            }
        }

    }
}
