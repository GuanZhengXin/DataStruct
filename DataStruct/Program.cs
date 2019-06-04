using System;
using System.Collections;
using Common;

namespace DataStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodeList = new LinkNode<int>();
            for (int i = 0; i < 5; i++)
            {
                nodeList.AddFirst(i);
            }
            nodeList.Add(2, 666);
            nodeList.Delete(0);
            Console.WriteLine(nodeList);
            Console.WriteLine(nodeList.GetLast());
            Console.ReadKey();
        }

        public static bool IsValid(string str)
        {
            var stack = new Stack();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '[' || str[i] == '{' || str[i] == '(')
                    stack.Push(str[i]);
                else if(str[i] == ']' || str[i] == '}' || str[i] == ')')
                {
                    if (stack.Count == 0)
                        return false;
                    var top = (char)stack.Pop();
                    if (str[i] == ')' && top != '(')
                        return false;
                    if (str[i] == ']' && top != '[')
                        return false;
                    if (str[i] == '}' && top != '{')
                        return false;
                }
            }
            return stack.Count==0;
        }
    }
}
