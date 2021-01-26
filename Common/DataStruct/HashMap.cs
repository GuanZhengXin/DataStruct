using System;
namespace Common.DataStruct
{
    /// <summary>
    /// 哈希表
    /// </summary>
    public class HashMap<K,V>
    {
        private V[] Data { get; set; }

        private int Capacity { get; set; }

        private int Mod { get; set; }

        public HashMap(int capacity = 71)
        {
            Capacity = capacity;
            Data = new V[capacity];
            Mod = 71;
        }

        private int GetHashIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % Mod);
        }

        public V Get(K key)
        {
            return Data[GetHashIndex(key)];
        }

        public void Set(K key,V value)
        {
            var index = GetHashIndex(key);
            Data[index] = value;
        }

    }
}
