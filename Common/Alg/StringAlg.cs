using System;
namespace Common.Alg
{
    /// <summary>
    /// 字符串匹配算法
    /// </summary>
    public class StringAlg
    {
        /// <summary>
        /// brute force 暴力匹配
        /// </summary>
        /// <param name="mainStr"></param>
        /// <param name="subStr"></param>
        /// <returns></returns>
        public static bool BF(string mainStr,string subStr)
        {
            if (mainStr.Length < subStr.Length)
                throw new ArgumentException("字串长度不得大于主串");

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

    }
}
