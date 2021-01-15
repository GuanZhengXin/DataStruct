using System;
namespace Common.Alg
{
    /// <summary>
    /// 树相关的
    /// </summary>
    public static class TreeAlg
    {
        /// <summary>
        /// 找到值为k的索引
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int? BinarySearch(int[] nums, int k)
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
        private static int? BinarySearch(int[] nums, int p, int r, int k)
        {
            if (p > r)
                return default;

            var mid = p + ((r - p) >> 1);
            Console.WriteLine($"p:{p},mid:{mid},r:{r}");
            if (k == nums[mid])
                return mid;
            else if (k < nums[mid])
                return BinarySearch(nums, p, mid - 1, k);
            else
                return BinarySearch(nums, mid + 1, r, k);
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
                }
                else if (k < nums[mid])
                {
                    high = mid - 1;
                }
                else
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
                if (nums[mid] < k)
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

        /// <summary>
        ///  堆排序 默认升序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="sort">0升序 1降序</param>
        /// <returns></returns>
        public static int[] HeapSort(int[] nums, int sort = 0)
        {
            Array<int> values;
            if (sort == 0)
            {
                var heap = new MaxHeap<int>(nums);
                values = heap.Sort();
            }
            else
            {
                var heap = new MinHeap<int>(nums);
                values = heap.Sort();
            }

            var size = values.GetSize();
            nums = new int[size];
            for (int i = 0; i < size; i++)
            {
                nums[i] = values.Get(i);
            }
            return nums;
        }
    }
}
