using System;
using System.Collections.Generic;

namespace Common.Tree
{
    /// <summary>
    /// 前缀树映射
    /// </summary>
    public class TrieMap
    {
        public class TrieNode
        {
            public TrieNode(bool isFind = false)
            {
                IsFind = isFind;
                Value = default;
                Next = new Dictionary<char, TrieNode>();
            }

            public Dictionary<char, TrieNode> Next { get; set; }

            public bool IsFind { get; set; }

            public int Value { get; set; }
        }

        public TrieNode Root { get; set; }

        public int Size { get; set; }

        public TrieMap()
        {
            Root = new TrieNode();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="word"></param>
        /// <param name="value"></param>
        public void Add(string word, int value)
        {
            var currentNode = Root;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!currentNode.Next.ContainsKey(c))
                    currentNode.Next.Add(c, new TrieNode());

                currentNode = currentNode.Next.GetValueOrDefault(c);
            }

            if (!currentNode.IsFind)
            {
                currentNode.IsFind = true;
                currentNode.Value = value;
                Size++;
            }
        }

        /// <summary>
        /// 元素大小
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool IsContains(string word)
        {
            var currentNode = Root;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!currentNode.Next.ContainsKey(c))
                    return false;

                currentNode = currentNode.Next.GetValueOrDefault(c);
            }

            return currentNode.IsFind;
        }

        /// <summary>
        /// 权重求和
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int Sum(string word)
        {
            var currentNode = Root;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!currentNode.Next.ContainsKey(c))
                    return default;

                currentNode = currentNode.Next.GetValueOrDefault(c);
            }
            return Sum(currentNode);
        }

        private int Sum(TrieNode node)
        {
            var res = node.Value;
            foreach (var key in node.Next.Keys)
            {
                res += Sum(node.Next.GetValueOrDefault(key));
            }
            return res;
        }

    }
}
