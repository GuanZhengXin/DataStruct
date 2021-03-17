using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Tree
{
    /// <summary>
    /// AC自动机  构建fail指针类似 KMP 多字符串模式匹配
    /// </summary>
    public class AcAutomatonTrie
    {
        public class AcAutomatonNode
        {
            public AcAutomatonNode(char str, int length, bool isFInd = false)
            {
                Value = str;
                IsFind = isFInd;
                Length = length;
                Children = new Dictionary<char, AcAutomatonNode>();
            }

            public char Value { get; set; }

            public Dictionary<char, AcAutomatonNode> Children { get; set; }
            //public AcAutomatonNode[] Children = new AcAutomatonNode[26];

            public AcAutomatonNode Fail { get; set; }

            public bool IsFind { get; set; }

            public int Length { get; set; }
        }

        /// <summary>
        /// 理论上所有文字
        /// </summary>
        private char[] AllWords { get; set; } = new char[] {
        '你','爱','我','贼','天','气','好','很','s','b','狗','a','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','t','u','v','w','x','y','z','坏'
        };

        public AcAutomatonNode Root { get; set; }

        public int Size { get; set; }

        public AcAutomatonTrie()
        {
            Root = new AcAutomatonNode(char.MinValue, 0);
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
                var str = word[i];
                if (!currentNode.Children.ContainsKey(str))
                    currentNode.Children.Add(str, new AcAutomatonNode(word[i], currentNode.Length + 1));//new AcAutomatonNode(word[i], currentNode.Length + 1);

                currentNode = currentNode.Children.GetValueOrDefault(str);
            }

            if (!currentNode.IsFind)
            {
                currentNode.IsFind = true;
                Size++;
            }
        }

        /// <summary>
        /// 构建失败指针
        /// </summary>
        public void BuildFailurePointer()
        {
            var queue = new Queue<AcAutomatonNode>();
            Root.Fail = null;
            queue.EnQueue(Root);
            while (!queue.IsEmpty())
            {
                var p = queue.DeQueue();
                for (int i = 0; i < AllWords.Length; ++i)
                {
                    var pc = p.Children.GetValueOrDefault(AllWords[i]);
                    if (pc == null) continue;
                    if (p == Root) //是否是第一层
                    {
                        pc.Fail = Root;
                    }
                    else
                    {
                        var q = p.Fail;
                        while (q != null)
                        {
                            var qc = q.Children.GetValueOrDefault(pc.Value);
                            if (qc != null)
                            {
                                pc.Fail = qc;
                                break;
                            }
                            q = q.Fail;
                        }
                        if (q == null)
                        {
                            pc.Fail = Root;
                        }
                    }
                    queue.EnQueue(pc);
                }
            }
        }


        public void Match(string text)
        { // text是主串
            int n = text.Length;
            var p = Root;
            for (int i = 0; i < n; ++i)
            {
                var str = text[i];
                while (p.Children.GetValueOrDefault(str) == null && p != Root)
                {
                    p = p.Fail; // 失败指针发挥作用的地方
                }
                p = p.Children.GetValueOrDefault(str);
                if (p == null) p = Root; // 如果没有匹配的，从root开始重新匹配
                AcAutomatonNode tmp = p;
                while (tmp != Root)
                { // 打印出可以匹配的模式串
                    if (tmp.IsFind == true)
                    {
                        int pos = i - tmp.Length + 1;
                        Console.WriteLine("匹配起始下标" + pos + "; 长度" + tmp.Length);
                    }
                    tmp = tmp.Fail;
                }
            }
        }

    }
}
