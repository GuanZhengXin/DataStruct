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
            //var bst = new BinarySearchTree<int>();
            //var numbers = new int[] { 10,5,2,7,6,4,1,8,15,20,12,11,17,13,22,18,19 };
            //foreach (var number in numbers)
            //{
            //    bst.Add(number);
            //}
            //bst.LayerTraverse();
            var nums1 = new int[] { 1, 2, 2, 1 };
            var nums2 = new int[] { 2, 2 };
            var res = Intersection2(nums1, nums2);
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
}
