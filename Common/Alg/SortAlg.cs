using System;
using System.Collections.Generic;

namespace Common.Alg
{
    public static class SortAlg
    {
        /// <summary>
        /// 冒泡算法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] nums)
        {
            for (int i= 0; i < nums.Length; i++)
            {
                var isSwap = false;
                for (int j = i+1; j < nums.Length; j++)
                {
                    if(nums[i]>nums[j])
                    {
                        var temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        isSwap = true;
                    }
                }

                if (!isSwap)
                    break;
            }
            return nums;
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] InsertSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                var val = nums[i];
                var j = i - 1;
                for (;  j>=0; j--)
                {
                    if (nums[j] <= val)
                        break;

                    nums[j + 1] = nums[j];
                }

                nums[j + 1] = val;
            }
            return nums;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] QuickSort(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                var minIndex = i;
                var minVal = nums[i];
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[j] < minVal)
                    {
                        minIndex = j;
                        minVal = nums[j];
                    }
                }

                if (minIndex != i)
                {
                    var temp = nums[i];
                    nums[i] = minVal;
                    nums[minIndex] = temp;
                }
            }
            return nums;
        }


    }
}
