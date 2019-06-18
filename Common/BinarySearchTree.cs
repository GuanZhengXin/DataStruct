using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 二分搜索树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable
    {
        public Node Root { get; set; }
        private int Size;
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }
            public Node(T value,Node left=null,Node right=null)
            {
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }
        }

        public int GetSize()
        {
            return this.Size;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Add(T value)
        {
            Root = AddNode(Root, value);
        }

        private Node AddNode(Node node, T value)
        {
            if (node == null)
                return new Node(value);

            if (node.Value.CompareTo(value) > 0)
                node.Left = AddNode(node.Left, value);
            else
                node.Right = AddNode(node.Right, value);
            return node;
        }

        public bool IsContains(T value)
        {
            return Contains(Root, value);
        }

        private bool Contains(Node node, T value)
        {
            if (node == null)
                return false;
            if (node.Value.CompareTo(value) > 0)
                return Contains(node.Left, value);
            else if(node.Value.CompareTo(value)<0)
                return Contains(node.Right, value);
            return true;
        }

        //深度优先遍历
        public void PreTraverse()
        {
            PreTraverse(Root);
        }

        private void PreTraverse(Node node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.Value);
            PreTraverse(node.Left);
            PreTraverse(node.Right);
        }

        // 广度优先遍历
        public void LayerTraverse()
        {
            var queue = new Queue<Node>();
            queue.EnQueue(Root);
            while (!queue.IsEmpty())
            {
                var currentNode = queue.DeQueue();
                Console.WriteLine(currentNode.Value);
                if (currentNode.Left != null)
                    queue.EnQueue(currentNode.Left);
                if (currentNode.Right != null)
                    queue.EnQueue(currentNode.Right);
            }
        }

        public void Delete(T value)
        {
            Root = SuccessorRemove(Root, value);
        }

        // 后继移除
        private Node SuccessorRemove(Node node,T value)
        {
            if (node == null)
                return null;

            if (node.Value.CompareTo(value) > 0)
            {
                node.Left = SuccessorRemove(node.Left, value);
                return node;
            }
            if (node.Value.CompareTo(value) < 0)
            {
                node.Right = SuccessorRemove(node.Right, value);
                return node;
            }
            else // Root.Value = value
            {
                if (node.Left == null)
                {
                    var rightNode = node.Right;
                    node.Right = null;
                    this.Size--;
                    return rightNode;
                }
                if (node.Right == null)
                {
                    var leftNode = node.Left;
                    node.Left = null;
                    this.Size--;
                    return leftNode;
                }
                // 左右子树 都有
                var successorNode = FindMinNode(node.Right);
                successorNode.Right = DeleteMin(node.Right);
                successorNode.Left = node.Left;
                node.Left = node.Right = null;
                return successorNode;
            }
        }

        private Node FindMinNode(Node node)
        {
            if (node == null)
                return default;
            var currentNode = node;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode;
        }

        public T DeleteMax()
        {
            var res = FindMax();
            Root = DeleteMax(Root);
            return res;
        }

        private Node DeleteMax(Node node)
        {
            if(node.Right == null)
            {
                var leftNode = node.Left;
                node.Right = null;
                this.Size--;
                return leftNode;
            }
            node.Right = DeleteMax(node.Right);
            return node;
        }

        public T DeleteMin()
        {
            var res = FindMin();
            Root = DeleteMin(Root);
            return res;
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                var rightNode = node.Right;
                node.Right = null;
                this.Size--;
                return rightNode;
            }
            node.Left = DeleteMin(node.Left);
            return node;
        }

        public T FindMin()
        {
            if (Root == null)
                return default;
            var currentNode = Root;
            while (currentNode.Left!=null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode.Value;
        }

        public T FindMax()
        {
            if (Root == null)
                return default;
            var currentNode = Root;
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode.Value;
        }

        public int GetRank(T value)
        {
            var nums = new List<T>();
            var queue = new Queue<Node>();
            queue.EnQueue(Root);
            while (!queue.IsEmpty())
            {
                var currentNode = queue.DeQueue();
                nums.Add(currentNode.Value);
                if (currentNode.Left != null)
                    queue.EnQueue(currentNode.Left);
                if (currentNode.Right != null)
                    queue.EnQueue(currentNode.Right);
            }
            nums = nums.OrderBy(i=>i).ToList();
            for (int i = 0; i < nums.Count()+1; i++)
            {
                if (nums[i].Equals(value))
                    return i+1;
            }
            return -1;
        }
    }
}
