using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Alg
{
    /// <summary>
    /// 排序算法
    /// </summary>
    public static class SortAlg
    {
        /// <summary>
        /// 冒泡算法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var isSwap = false;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
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
                for (; j >= 0; j--)
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
        /// 选择排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SelectionSort(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                var minIndex = i;
                var minVal = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
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

        /// <summary>
        /// 归并排序 分治思想 nlogn
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] MergeSort(int[] nums)
        {
            return MergeSort(nums,0,nums.Length);
        }

        /// <summary>
        /// 归并排序 分治思想 nlogn
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="p">开始索引下标</param>
        /// <param name="r">结束索引下标</param>
        /// <returns></returns>
        private static int[] MergeSort(int[] nums, int p, int r)
        {
            if (p >= r)
                return new int[] { nums[p] };

            var q = (p + r) / 2;
            var num1 = MergeSort(nums, p, q);
            var num2 = MergeSort(nums, q + 1, r);
            return MergeArray(num1, num2);
        }

        private static int[] MergeArray(int[] num1, int[] num2)
        {
            var temp = new int[num1.Length + num2.Length];
            var i = 0;
            var j = 0;
            var k = 0;

            while (i < num1.Length && j < num2.Length)
            {
                if (num1[i] <= num2[j])
                {
                    temp[k] = num1[i];
                    i++;
                }
                else
                {
                    temp[k] = num2[j];
                    j++;
                }

                k++;
            }

            if (i == num1.Length)
            {
                for (int x = j; x < num2.Length; x++)
                {
                    temp[k++] = num2[x];
                }
            }
            else if (j == num2.Length)
            {
                for (int x = i; x < num1.Length; x++)
                {
                    temp[k++] = num1[x];
                }
            }
            return temp;
        }

        /// <summary>
        /// 快速排序  设立分区点
        /// </summary>
        /// <param name="nums"></param>
        public static void QuickSort(ref int[] nums)
        {
            QuickSort(ref nums, 0, nums.Length - 1);
        }

        private static void QuickSort(ref int[] nums, int p, int r)
        {
            if (p >= r)
                return;

            var q = Partition(ref nums, p, r);
            QuickSort(ref nums, p, q - 1);
            QuickSort(ref nums, q + 1, r);
        }

        private static int Partition(ref int[] nums,int p, int r)
        {
            var pivot = nums[r];
            var i = p;
            for (int j = p; j < r; j++)
            {
                if(nums[j] < pivot)
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
        /// 桶排序 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] BucketSort(int[] nums)
        {
            var min = nums.Min();
            var avg = (nums.Max() - min) / 2;
            var bucket1 = new int[nums.Length/2];
            var bucket2 = new int[nums.Length - bucket1.Length];
            var x = 0;
            var j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= avg)
                    bucket1[x++] = nums[i];
                else
                    bucket2[j++] = nums[i];
            }

            QuickSort(ref bucket1);
            QuickSort(ref bucket2);
            return MergeArray(bucket1, bucket2);
        }

        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] CountingSort(int[] nums)
        {
            var min = nums.Min();
            var resArray = new int[nums.Length];
            var countArray = new int[nums.Max() - min + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                var index = nums[i] - min;
                for (int j = countArray.Length - 1; j >= index; j--)
                {
                    countArray[j]++;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var index = -- countArray[nums[i] - min];
                resArray[index] = nums[i];
            }

            return resArray;
        }

        /// <summary>
        /// 基数排序  位比较排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] RadixSort(int[] nums)
        {
            return nums;
        }

        public static int? BinarySearch(int[] nums,int k)
        {
            return BinarySearch(nums, 0, nums.Length - 1, k);
        }

        /// <summary>
        /// 二分搜索树
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static int? BinarySearch(int[] nums,int p, int r,int k)
        {
            if (p > r)
                return default;

            var mid = p + ((r - p) >> 1);
            Console.WriteLine($"p:{p},mid:{mid},r:{r}");
            if (k == nums[mid])
                return mid;
            else if (k < nums[mid])
                return BinarySearch(nums,p ,mid-1,k);
            else
                return BinarySearch(nums, mid+1, r, k);
        }

        /// <summary>
        /// 查找第一个相等的元素索引
        /// </summary>
        /// <returns></returns>
        public static int? BinarySearchFirstEq(int[] nums, int k)
        {
            var low = 0;
            var high = nums.Length - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (k > nums[mid])
                {
                    low = mid + 1;
                } else if (k < nums[mid])
                {
                    high = mid - 1;
                } else
                {
                    if (mid == 0 || nums[mid - 1] != k)
                        return mid;
                    else
                        high = mid - 1;
                };
            }

            return default;
        }

        /// <summary>
        /// 查找最后一个相等的元素索引
        /// </summary>
        /// <returns></returns>
        public static int? BinarySearchLastEq(int[] nums, int k)
        {
            var low = 0;
            var high = nums.Length - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (k > nums[mid])
                {
                    low = mid + 1;
                }
                else if (k < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    if (mid == nums.Length || nums[mid + 1] != k)
                        return mid;
                    else
                        low = mid + 1;
                };
            }

            return default;
        }

        /// <summary>
        /// 查找第一个大于相等的元素索引
        /// </summary>
        /// <returns></returns>
        public static int? BinarySearchFirstGe(int[] nums, int k)
        {
            var low = 0;
            var high = nums.Length - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (nums[mid]< k)
                {
                    low = mid + 1;
                }
                else if (nums[mid] >= k)
                {
                    if (mid == 0 || nums[mid - 1] < k)
                        return mid;
                    else
                        high = mid - 1;
                };
            }

            return default;
        }

        /// <summary>
        /// 查找最后一个小于相等的元素索引
        /// </summary>
        /// <returns></returns>
        public static int? BinarySearchLastLe(int[] nums, int k)
        {
            var low = 0;
            var high = nums.Length - 1;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                if (nums[mid] <= k)
                {
                    if (mid == nums.Length || nums[mid + 1] > k)
                        return mid;
                    else
                        low = mid + 1;
                }
                else if (nums[mid] >= k)
                {
                    high = mid - 1;
                };
            }

            return default;
        }
    }
}
