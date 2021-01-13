using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Tree
{
    /// <summary>
    /// 字典树
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
        public void Add(string value)
        {
            var currentNode = Root;
            for (int i = 0; i < value.Length; i++)
            {
                var c = value[i];
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            GetStrings(Root);
            return sb.ToString();
        }

        private string GetStrings(TrieNode node)
        {
            var sb = new StringBuilder();
            var currentDict = Root.Next;
            var layer = 1;
            while (currentDict.Count!=0)
            {
                foreach (var key in currentDict.Keys)
                {
                    return GetStrings(currentDict[key]);
                }
            }
            return sb.ToString();
        }

    }
}
