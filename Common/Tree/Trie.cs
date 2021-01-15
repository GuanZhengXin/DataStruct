using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Tree
{
    /// <summary>
    /// 字典树(前缀树) n叉树 这里是字符（相当于单词表)
    /// </summary>
    public class Trie
    {
        public class TrieNode
        {
            public TrieNode(bool isFind = false)
            {
                IsFind = isFind;
                Next = new Dictionary<char, TrieNode>();
            }

            public Dictionary<char, TrieNode> Next { get; set; }

            public bool IsFind{ get; set; }
        }

        public TrieNode Root { get; set; }

        public int Size { get; set; }

        public Trie()
        {
            Root = new TrieNode();
        }

        /// <summary>
        /// 添加一个单词
        /// </summary>
        /// <param name="value"></param>
        public void Add(string word)
        {
            var currentNode = Root;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!currentNode.Next.ContainsKey(c))
                    currentNode.Next.Add(c,new TrieNode());

                currentNode = currentNode.Next.GetValueOrDefault(c);
            }

            if (!currentNode.IsFind)
            {
                currentNode.IsFind = true;
                Size++;
            }                
        }

        /// <summary>
        /// 得到单词个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// 查询是否包含某个字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public bool IsContain(string word)
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
        /// 前缀是否包含某个字符
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool PreSearch(string word)
        {
            var currentNode = Root;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!currentNode.Next.ContainsKey(c))
                    return false;

                currentNode = currentNode.Next.GetValueOrDefault(c);
            }

            return true;
        }

        /// <summary>
        /// 通配符匹配 .
        /// </summary>
        /// <returns></returns>
        public bool IsRegexMatch(string word)
        {
            return Match(Root,word,0);
        }

        private bool Match(TrieNode node,string word,int index)
        {
            if (index == word.Length)
                return node.IsFind;

            var c = word[index];
            if (c.ToString() == ".")
            {
                foreach (var key in node.Next.Keys)
                {
                    if (Match(node.Next.GetValueOrDefault(key), word, index + 1))
                        return true;
                }

                return false;
            }
            else
            {
                if (node.Next.GetValueOrDefault(c) == null)
                    return false;

                return Match(node.Next.GetValueOrDefault(c), word, index + 1);
            }
        }

        /// <summary>
        /// 移除单词
        /// </summary>
        /// <param name="word"></param>
        public void Remove(string word)
        {
            if (!IsContain(word))
                return;

            var currentNode = Root;
            var markNode = Root;
            char removeChar = default;
            var isStop = false;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                TrieNode currentPreNode = currentNode;
                currentNode = currentNode.Next.GetValueOrDefault(c);
                if (currentNode.Next.Count == 1 && !isStop)
                {
                    markNode = currentPreNode;
                    removeChar = c;
                    isStop = true;
                }
            }

            if (currentNode.Next.Count != 0)
            {
                currentNode.IsFind = false;
                return;
            }

            markNode.Next.Remove(removeChar);
        }

    }
}
