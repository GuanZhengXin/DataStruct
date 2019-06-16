using System;
using System.Collections;
using Common;

namespace DataStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinarySearchTree<int>();
            var numbers = new int[] { 10,5,2,7,6,4,1,8,15,20,12,11,17,13,22,18,19 };
            foreach (var number in numbers)
            {
                bst.Add(number);
            }
            bst.LayerTraverse();
            Console.WriteLine(bst.GetDepth());
            Console.ReadKey();
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
    }
}
