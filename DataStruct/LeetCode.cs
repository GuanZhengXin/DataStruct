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

        /// <summary>
        /// 得到窗口最大值 窗口会一直移动
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="windowsSize"></param>
        /// <returns></returns>
        public static int[] GetWindosMax(int[] nums, int windowSize = 3)
        {
            var res = new int[] { };
            var window = new int[windowSize];
            var maxVal = window[0];
            for (int i = 0; i < windowSize; i++)
            {
                if (i != 0)
                {
                    if (window[i] > window[i - 1])
                        maxVal = window[i];
                    else
                        maxVal = window[i-1];
                }
                    
                window[i] = nums[i];
            }


            return res;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode root = new ListNode(0);
            ListNode cursor = root;
            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                int l1Val = l1 != null ? l1.val : 0;
                int l2Val = l2 != null ? l2.val : 0;
                int sumVal = l1Val + l2Val + carry;
                carry = sumVal / 10;

                ListNode sumNode = new ListNode(sumVal % 10);
                cursor.next = sumNode;
                cursor = sumNode;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return root.next;

            //var position = 0;
            //var curretNode1 = l1;
            //var curretNode2 = l2;
            //var res = 0;
            //while (curretNode1 != null && curretNode2 != null)
            //{
            //    res += (curretNode1.val + curretNode2.val) * (int)Math.Pow(10, position);
            //    curretNode1 = curretNode1.next;
            //    curretNode2 = curretNode2.next;
            //    position++;
            //}

            //if (curretNode1 == null)
            //{
            //    while (curretNode2!=null)
            //    {
            //        res += curretNode2.val * (int)Math.Pow(10, position);
            //        curretNode2 = curretNode2.next;
            //        position++;
            //    }
            //}else if(curretNode2 == null)
            //{
            //    while (curretNode1 != null)
            //    {
            //        res += curretNode1.val * (int)Math.Pow(10, position);
            //        curretNode1 = curretNode1.next;
            //        position++;
            //    }
            //}

            //var startNode = new ListNode(0);
            //var currentNode = startNode;
            //var post = res.ToString().Length;
            //for (int i = 0; i < post; i++)
            //{
            //    var node = new ListNode
            //    {
            //        val = (res / ((int)Math.Pow(10, i))) % 10
            //    };
            //    currentNode.next = node;
            //    currentNode = node;
            //}

            //return startNode.next;
        }


        /// <summary>
        /// 排列组合
        /// </summary>
        /// <param name="data"></param>
        /// <param name="n"></param>
        /// <param name="k"></param>
        public static void PrintPermutations(int[] data, int k)
        {
            if (k == 1)
            {
                for (int i = 0; i < data.Length; ++i)
                {
                    Console.WriteLine(data[i] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < k; ++i)
            {
                int tmp = data[i];
                data[i] = data[k - 1];
                data[k - 1] = tmp;

                PrintPermutations(data, k - 1);

                tmp = data[i];
                data[i] = data[k - 1];
                data[k - 1] = tmp;
            }
        }

    }
}
