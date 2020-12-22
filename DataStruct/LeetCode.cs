using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStruct
{
    public static class LeetCodeExtension
    {
        /// <summary>
        /// 两数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    return new int[] { dict[nums[i]],i };
                }

                dict.Add(target - nums[i],i);
            }
            return new int[] { }; 
        }

        /// <summary>
        /// 字符是否有效
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsValid(string str)
        {
            //var stack = new Stack();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str[i] == '[' || str[i] == '{' || str[i] == '(')
            //        stack.Push(str[i]);
            //    else if (str[i] == ']' || str[i] == '}' || str[i] == ')')
            //    {
            //        if (stack.Count == 0)
            //            return false;
            //        var top = (char)stack.Pop();
            //        if (str[i] == ')' && top != '(')
            //            return false;
            //        if (str[i] == ']' && top != '[')
            //            return false;
            //        if (str[i] == '}' && top != '{')
            //            return false;
            //    }
            //}
            //return stack.Count == 0;


            var dict = new Dictionary<string, string>
            {
                { "(", ")" },
                { "{", "}" },
                { "[", "]" }
            };
            var stack = new Stack();

            for (int i = 0; i < str.Length; i++)
            {
                if (!dict.ContainsKey(i.ToString()))
                {
                    if (stack.Pop().ToString() != dict[i.ToString()])
                        return false;
                }
                else
                    stack.Push(i);
            }
            return stack.Count == 0;
    }
    }
}
