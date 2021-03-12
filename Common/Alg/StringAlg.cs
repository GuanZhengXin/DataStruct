using System;
namespace Common.Alg
{
    /// <summary>
    /// 字符串匹配算法
    /// </summary>
    public class StringAlg
    {
        private static void CheckString(string mainStr, string subStr)
        {
            if (mainStr.Length < subStr.Length)
                throw new ArgumentException("字串长度不得大于主串");
        }

        /// <summary>
        /// brute force 暴力匹配
        /// </summary>
        /// <param name="mainStr"></param>
        /// <param name="subStr"></param>
        /// <returns></returns>
        public static bool BF(string mainStr, string subStr)
        {
            CheckString(mainStr, subStr);
            var currentIndex = 0;
            var maxIndex = mainStr.Length - subStr.Length;
            while (currentIndex <= maxIndex)
            {
                for (int j = 0; j < subStr.Length; j++)
                {
                    if (subStr[j] == mainStr[j + currentIndex])
                    {
                        if (j == subStr.Length - 1)
                            return true;

                        continue;
                    }

                    currentIndex++;
                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// RK算法 哈希字符串
        /// </summary>
        /// <param name="mainStr"></param>
        /// <param name="subStr"></param>
        /// <returns></returns>
        public static bool RK(string mainStr, string subStr)
        {
            CheckString(mainStr, subStr);
            var currentIndex = 0;
            var maxIndex = mainStr.Length - subStr.Length;
            var subStrHash = GetStringHash(subStr);
            while (currentIndex <= maxIndex)
            {
                var hashStr = mainStr.Substring(currentIndex, subStr.Length);
                if (subStrHash != GetStringHash(hashStr))
                {
                    currentIndex++;
                    continue;
                }
                else // 解决 hash冲突
                {
                    for (int i = 0; i < subStr.Length; i++)
                    {
                        if (subStr[i] != mainStr[i + currentIndex])
                        {
                            currentIndex++;
                            break;
                        }

                        if (i == subStr.Length - 1)
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 自定义哈希算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static int GetStringHash(string str)
        {
            var res = default(int);
            foreach (var item in str)
            {
                res += GetCharHash(item);
            }
            return res;
        }

        private static byte GetCharHash(char c)
        {
            return System.Text.Encoding.ASCII.GetBytes(new char[] { c })[0];
        }

        /// <summary>
        /// BM算法 
        /// </summary>
        /// <param name="mainStr"></param>
        /// <param name="subStr"></param>
        public static bool BM(string mainStr, string subStr)
        {
            CheckString(mainStr, subStr);
            var currentIndex = 0;
            var suffix = new int[subStr.Length];
            var prefix = new bool[subStr.Length];
            GenerateGS(subStr, ref suffix, ref prefix);
            while (currentIndex <= mainStr.Length - subStr.Length)
            {
                int badIndex;
                for (badIndex = subStr.Length - 1; badIndex >= 0; --badIndex)
                {
                    if (mainStr[currentIndex + badIndex] != subStr[badIndex])
                        break;
                }

                if (badIndex < 0)
                    return true;

                int badRegMap = badIndex - GetBadRegMap(mainStr, subStr, badIndex, badIndex + currentIndex);
                int goodRegMap = 0;
                if (badIndex < subStr.Length - 1)
                    goodRegMap = GetMapByGS(badIndex, subStr.Length, suffix, prefix);

                currentIndex += Math.Max(badRegMap, goodRegMap);
            }

            return false;
        }

        /// <summary>
        /// 得到好后缀规则的偏移长度
        /// </summary>
        /// <param name="badIndex">坏字符所在的索引</param>
        /// <param name="subStrLength">模式串长度</param>
        /// <param name="suffix">下标是后缀的长度，值为另一个后缀的第一个字符的索引 没有匹配为-1</param>
        /// <param name="prefix">下标是后缀的长度，值为是否可完全匹配到前缀字符</param>
        /// <returns></returns>
        private static int GetMapByGS(int badIndex, int subStrLength, int[] suffix, bool[] prefix)
        {
            int k = subStrLength - 1 - badIndex;
            if (suffix[k] != -1)
                return badIndex - suffix[k] + 1;

            for (int r = badIndex + 2; r <= subStrLength - 1; ++r)
            {
                if (prefix[subStrLength - r])
                    return r;
            }

            return subStrLength;
        }

        /// <summary>
        /// b表示模式串，m表示长度，suffix，prefix数组事先申请好了
        /// </summary>
        /// <param name="subStr"></param>
        /// <param name="suffix"></param>
        /// <param name="prefix"></param>
        private static void GenerateGS(string subStr, ref int[] suffix, ref bool[] prefix)
        {
            var subStrLength = subStr.Length;
            for (int i = 0; i < subStrLength; ++i)
            {
                suffix[i] = -1;
                prefix[i] = false;
            }
            for (int i = 0; i < subStrLength - 1; ++i)
            {
                int j = i;
                int k = 0; // 公共后缀子串长度
                while (j >= 0 && subStr[j] == subStr[subStrLength - 1 - k])
                { // 与b[0, m-1]求公共后缀子串
                    --j;
                    ++k;
                    suffix[k] = j + 1; //j+1表示公共后缀子串在b[0, i]中的起始下标
                }
                if (j == -1) prefix[k] = true; //如果公共后缀子串也是模式串的前缀子串
            }
        }

        /// <summary>
        /// 坏字符规则
        /// </summary>
        /// <param name="mainStr"></param>
        /// <param name="subStr"></param>
        /// <param name="badIndex"></param>
        /// <param name="mainIndex"></param>
        /// <returns></returns>
        private static int GetBadRegMap(string mainStr, string subStr, int badIndex, int mainIndex)
        {
            return badIndex - FindLstPos(subStr, mainStr[mainIndex]);
        }

        /// <summary>
        /// 找到该字符在所在字符串的最后一个索引
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int FindLstPos(string str, char c)
        {
            var index = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    index = i;
            }

            return index;
        }

        /// <summary>
        /// kmp算法
        /// </summary>
        /// <param name="mainStr"></param>
        /// <param name="subStr"></param>
        /// <returns></returns>
        public static int KMP(string mainStr, string subStr)
        {
            var next = GetNextNums(subStr);
            var j = 0;
            for (int i = 0; i < mainStr.Length; i++)
            {
                while (j > 0 && mainStr[i] != subStr[j])
                {
                    j = next[j - 1] + 1;
                }

                if (mainStr[i] == subStr[j])
                    j++;

                if (j == mainStr.Length)
                    return i - mainStr.Length + 1;
            }

            return -1;
        }

        /// <summary>
        /// 数组的下标是每个前缀结尾字符下标，数组的值是这个前缀的最长可以匹配前缀子串的结尾字符下标。
        /// 比如  a b a   next[3] = 0   ;   a b a b a netx[5] = 2
        /// </summary>
        /// <param name="subStr"></param>
        /// <returns></returns>
        public static int[] GetNextNums(string subStr)
        {
            int[] next = new int[subStr.Length];
            next[0] = -1;
            int k = -1;
            for (int i = 1; i < subStr.Length; ++i)
            {
                while (k != -1 && subStr[k + 1] != subStr[i])
                {
                    k = next[k];
                }

                if (subStr[k + 1] == subStr[i])
                    ++k;

                next[i] = k;
            }
            return next;
        }
    }
}
