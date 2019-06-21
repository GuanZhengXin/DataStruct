using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Common;

namespace DataStruct
{
    class Program
    {
        static void Main(string[] args)
        {

            var nums1 = new int[] { -347, -990, 830, -654, -336, -255, -378, -670, 336, 481, 420, 986, 982 ,982,-990,420};
            var s = new Solution();
            var res = s.TopKFrequent(nums1, 3);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public void A()
        {
            B();
        }

        public void B()
        {
            C();
        }

        public void C()
        {
            //....
        }

        public static bool IsValid(string str)
        {
            var stack = new Stack();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '[' || str[i] == '{' || str[i] == '(')
                    stack.Push(str[i]);
                else if(str[i] == ']' || str[i] == '}' || str[i] == ')')
                {
                    if (stack.Count == 0)
                        return false;
                    var top = (char)stack.Pop();
                    if (str[i] == ')' && top != '(')
                        return false;
                    if (str[i] == ']' && top != '[')
                        return false;
                    if (str[i] == '}' && top != '{')
                        return false;
                }
            }
            return stack.Count==0;
        }

        public static int UniqueMorseRepresentations(string[] words)
        {
            var codes = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            SortedSet<string> set = new SortedSet<string>();
            foreach (var word in words)
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < word.Length; i++)
                {
                    stringBuilder.Append(codes[word.ToCharArray()[i] - 'a']);
                }
                set.Add(stringBuilder.ToString());
            }
            return set.Count;
        }

        public class Student : IComparable
        {
            public Student(string name, int age, char gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }

            public string Name { get; set; }
            public int Age { get; set; }
            public char Gender { get; set; }

            public int CompareTo(object obj)
            {
                var stu = obj as Student;
                return this.Age - stu.Age;
            }

            public override bool Equals(object obj)
            {
                var stu = obj as Student;
                return this.Age == stu.Age;
            }
        }

        public static int[] Intersection1(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            var set = new SortedSet<int>();
            foreach (var num in nums1)
            {
                set.Add(num);
            }
            foreach (var num in nums2)
            {
                if (set.Contains(num))
                {
                    list.Add(num);
                    set.Remove(num);
                }
            }
            return list.ToArray();
        }

        public static int[] Intersection2(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            var dic = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                if (!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else
                    dic[num]++;
            }
            foreach (var num in nums2)
            {
                if (dic.ContainsKey(num))
                {
                    list.Add(num);
                    dic[num]--;
                    if (dic[num] == 0)
                    {
                        dic.Remove(num);
                    }
                }

            }
            return list.ToArray();
        }
    }

    public class Solution
    {
        private class Demo : IComparable
        {
            public int value;
            public int Freq;

            public Demo(int value, int freq)
            {
                this.value = value;
                Freq = freq;
            }

            public int CompareTo(object obj)
            {
                var demo = obj as Demo;
                if (this.Freq < demo.Freq)
                    return 1;
                else if (this.Freq > demo.Freq)
                    return -1;
                else
                {
                    if (this.value > demo.value)
                        return 1;
                    else
                        return 0;
                }
                    
            }
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict.Add(num, 1);
            }

            var pqList = new ProperityQueue<Demo>();
            foreach (var key in dict.Keys)
            {
                if (pqList.GetSize() < k)
                    pqList.EnQueue(new Demo(key, dict[key]));
                else if (dict[key] > pqList.Peek().Freq)
                {
                    pqList.DeQueue();
                    pqList.EnQueue(new Demo(key, dict[key]));
                }

            }
            var list = new List<int>();
            while (!pqList.IsEmpty())
            {
                list.Add(pqList.DeQueue().value);
            }
            return list;
        }
    }
}
