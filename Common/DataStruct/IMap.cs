using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IMap<K,V>
    {
        bool IsContains(K key);
        int GetSize();
        void Add(K key, V value);
        void Set(K key, V value);
        void Delete(K key);
        bool IsEmpty();
        V Get(K key);
    }
}
