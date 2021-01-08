using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tree
{
    /// <summary>
    /// 二分搜索树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>  where T: IComparable
    {
        private TreeNode Root { get; set; }
        public int Size { get; set; }

        public class TreeNode
        {
            public TreeNode(T value,TreeNode left = null, TreeNode right = null)
            {
                Left = left;
                Right = right;
                Value = value;
            }

            public TreeNode()
            {
                
            }

            public TreeNode Left { get; set; }

            public TreeNode Right { get; set; }

            public T Value { get; set; }
        }

        /// <summary>
        /// 得到总数量
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// 树是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Size == 0;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="value">元素值</param>
        public void Add(T value)
        {
            Root = AddNode(Root, value);
            Size++;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node"><父亲节点/param>
        /// <param name="value">元素值</param>
        /// <returns></returns>
        private TreeNode AddNode(TreeNode node,T value)
        {
            if (node == null)
                return new TreeNode(value);

            if (node.Value.CompareTo(value) > 0)
                node.Left = AddNode(node.Left, value);
            else
                node.Right = AddNode(node.Right, value);
            return node;
        }

        /// <summary>
        /// 查找某个值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode Find(T value)
        {
            var currentNode = Root;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) > 0)
                {
                    currentNode = currentNode.Left;
                }
                else if(currentNode.Value.CompareTo(value) < 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return currentNode;
                }
            }
            return currentNode;
        }

        /// <summary>
        /// 找到最大值
        /// </summary>
        /// <returns></returns>
        public T FindMax()
        {
            if (Root == null)
                return default;

            return FindMaxValue(Root);
        }

        private T FindMaxValue(TreeNode node)
        {
            if (node.Right == null)
                return node.Value;

            return FindMaxValue(node.Right);
        }

        private TreeNode FindMaxNode(TreeNode node)
        {
            if (node.Right == null)
                return node;

            return FindMaxNode(node.Right);
        }

        /// <summary>
        /// 找到最小值
        /// </summary>
        /// <returns></returns>
        public T FindMin()
        {
            if (Root == null)
                return default;

            return FindMinValue(Root);
        }

        private T FindMinValue(TreeNode node)
        {
            if (node.Left == null)
                return node.Value;

            return FindMinValue(node.Left);
        }

        private TreeNode FindMinNode(TreeNode node)
        {
            if (node.Left == null)
                return node;

            return FindMinNode(node.Left);
        }

        /// <summary>
        /// 删除最大元素
        /// </summary>
        public void DeleteMax()
        {
            if (Root == null)
                return;

            Root = DeleteMax(Root);
        }

        private TreeNode DeleteMax(TreeNode node)
        {
            if (node.Right == null)
            {
                var leftNode = node.Left;
                node.Left = null;
                Size--;
                return leftNode;
            }

            node.Right = DeleteMax(node.Right);
            return node;
        }

        /// <summary>
        /// 删除最小元素
        /// </summary>
        public void DeleteMin()
        {
            if (Root == null)
                return;

            Root = DeleteMin(Root);
        }

        public TreeNode DeleteMin(TreeNode node)
        {
            if (node.Left == null)
            {
                var rightNode = node.Right;
                node.Right = null;
                Size--;
                return rightNode;
            }
            node.Left = DeleteMin(node.Left);
            return node;
        }

        /// <summary>
        /// 前序遍历 先打印这个节点，然后再打印它的左子树，最后打印它的右子树。
        /// </summary>
        public void PreOrder()
        {
            PreOrder(Root);
        }

        private void PreOrder(TreeNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        /// <summary>
        /// 中序遍历 对于树中的任意节点来说，先打印它的左子树，然后再打印它本身，最后打印它的右子树。
        /// </summary>
        public void InOrder()
        {
            InOrder(Root);
        }

        private void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.WriteLine(node.Value);
                InOrder(node.Right);
            }
        }

        /// <summary>
        /// 后序遍历 对于树中的任意节点来说，先打印它的左子树，然后再打印它的右子树，最后打印这个节点本身。
        /// </summary>
        public void PostOrder()
        {
            PostOrder(Root);
        }

        private void PostOrder(TreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.WriteLine(node.Value);
            }
        }

        /// <summary>
        /// 广度遍历 层序遍历
        /// </summary>
        public void LayerTraverse()
        {
            var queue = new Queue<TreeNode>();
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

        /// <summary>
        /// 是否包含某个值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsContains(T value)
        {
            return Contains(Root, value);
        }

        private bool Contains(TreeNode node, T value)
        {
            if (node == null)
                return false;

            if (node.Value.CompareTo(value) == 0)
                return true;
            else if (node.Value.CompareTo(value) > 0)
                return Contains(node.Left, value);
            else
                return Contains(node.Right, value);
        }

        /// <summary>
        /// 查找值的排名
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int FindRank(T value)
        {
            var nums = new List<T>();
            var queue = new Queue<TreeNode>();
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
            nums = nums.OrderBy(i => i).ToList();
            for (int i = 0; i < nums.Count() + 1; i++)
            {
                if (nums[i].Equals(value))
                    return i + 1;
            }
            return -1;
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="value"></param>
        public void Delete(T value)
        {
            Root = SuccessorRemove(Root,value);
        }

        public TreeNode SuccessorRemove(TreeNode node, T value)
        {
            if (node == null)
                return default;

            if (node.Value.CompareTo(value) > 0)
            {
                node.Left  = SuccessorRemove(node.Left, value);
                return node;
            }else if (node.Value.CompareTo(value) < 0)
            {
                node.Right = SuccessorRemove(node.Right, value);
                return node;
            }
            else {
                if (node.Left == null)
                {
                    var rightNode = node.Right;
                    node.Right = null;
                    Size--;
                    return rightNode;
                }

                if (node.Right == null)
                {
                    var leftNode = node.Left;
                    node.Left = null;
                    Size--;
                    return leftNode;
                }

                var successor = FindMinNode(node.Right);
                successor.Right = DeleteMin(node.Right);
                successor.Left = node.Left;
                node.Left = node.Right = null;
                Size--;
                return successor;
            }
        }

    }
}
