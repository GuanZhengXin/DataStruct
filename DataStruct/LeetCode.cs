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

        /// <summary>
        /// 得到第k大元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int? GetMaxKElement(int[] nums, int k)
        {
            var res = new int[nums.Length];
            nums.CopyTo(res,0);
            return QuickSort(ref res, 0, nums.Length-1,k);
        }

        public static int? QuickSort(ref int[] nums,int p,int r,int k)
        {
            if (p >= r)
                return default;

            var q = PartationSort(ref nums, p, r);
            if (q == k - 1)
                return nums[q];
            else if (q > k - 1)
                return QuickSort(ref nums, p, q - 1, k);
            else
                return QuickSort(ref nums, q + 1, r,k);
        }

        private static int PartationSort(ref int[] nums,int p, int r)
        {
            var pivot = nums[r];
            var i = p;
            for (int j = p; j < r; j++)
            {
                if (nums[j] < pivot)
                {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                }
            }

            var temp1 = nums[i];
            nums[i] = nums[r];
            nums[r] = temp1;
            return i;
        }

        /// <summary>
        /// 实现“求一个数的平方根”？要求精确到小数点后6位。
        /// </summary>
        /// <param name=""></param>
        /// <param name="presion"></param>
        /// <returns></returns>
        public static double Sqrt(double num,int presion=2)
        {
            var max = num;
            var min = 0;
            var half = (double)num / 2;
            if (half == num / half)
                return half;
            else if (half > num / half)
            {
                max = half;
                return Sqrt(half, presion);
            }
            
            return 0;
        }

    }
}
