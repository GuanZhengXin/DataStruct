using System;
using Common.Tree;

namespace Common.DataStruct
{
    /// <summary>
    /// 哈希表
    /// </summary>
    public class HashMap<K,V> where K: IComparable
    {
        private AVLTreeMap<K,V>[] Datas { get; set; }

        private int Capacity { get; set; }

        private int Size { get; set; }

        public HashMap(int capacity = 71)
        {
            Capacity = capacity;
            Datas = new AVLTreeMap<K, V>[capacity];
            for (int i = 0; i < Datas.Length; i++)
            {
                Datas[i] = new AVLTreeMap<K, V>();
            }
        }

        private int GetHashIndex(K key)
        {
            return key.GetHashCode() & 0X7ffffff % Capacity;
        }

        /// <summary>
        /// 得到key对应的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            return Datas[GetHashIndex(key)].Get(key);
        }

        /// <summary>
        /// 得到个数大小
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// 设置键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(K key,V value)
        {
            var index = GetHashIndex(key);
            if (Datas[index].IsContains(key))
            {
                Datas[index].Set(key, value);
            }
            else
            {
                Datas[index].Add(key,value);
                Size++;
            }
        }

        /// <summary>
        /// 移除元素
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            if (!Datas[GetHashIndex(key)].IsContains(key))
                return;

            Datas[GetHashIndex(key)].Delete(key);
            Size--;
        }

    }
}
