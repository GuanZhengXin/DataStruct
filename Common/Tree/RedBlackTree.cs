using System;
namespace Common.Tree
{
    /// <summary>
    /// 红黑树 每个节点要么是红色，要么是黑色。根节点必须是黑色.红色节点不能连续（也即是，红色节点的孩子和父亲都不能是红色）。对于每个节点，从该点至null（树尾端）的任何路径，都含有相同个数的黑色节点。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RedBlackTree<T> where T : IComparable
    {
        private int Size { get; set; }

        private TreeNode Root { get; set; }

        public enum TreeNodeColor
        {
            Red = 1,
            Black = 2
        }

        public class TreeNode
        {
            public TreeNode(T value,TreeNode left, TreeNode right,TreeNodeColor treeNodeColor = TreeNodeColor.Black)
            {
                Left = left;
                Right = right;
                Value = value;
                Color = treeNodeColor;
            }

            public TreeNode()
            {
            }

            public TreeNode Left { get; set; }

            public TreeNode Right { get; set; }

            public T Value { get; set; }

            public TreeNodeColor Color { get; set; }
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (Size != 0)
                Root = Add(Root, value, TreeNodeColor.Red);
            else
                Root = new TreeNode(value, default, default, TreeNodeColor.Black);
            Size++;
        }

        private TreeNode Add(TreeNode node,T value, TreeNodeColor color = TreeNodeColor.Red)
        {
            if (node == null)
                return new TreeNode(value,default,default,color);

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.Left == null && node.Color != TreeNodeColor.Black)
                {
                    // todo
                    Console.WriteLine("need digest");
                }
                node.Left = Add(node.Left, value);
            }
            else
            {
                if (node.Right == null && node.Color != TreeNodeColor.Black)
                {
                    // todo
                    Console.WriteLine("need digest");
                }
                node.Right = Add(node.Right, value);
            }
            return node;
        }

        /// <summary>
        /// 左旋
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode RotateLeft(TreeNode node)
        {
            var rightNode = node.Right;
            var leftNode = node.Right?.Left;
            rightNode.Left = node;
            node.Right = leftNode;
            return rightNode;
        }

        /// <summary>
        /// 右旋
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode RotateRight(TreeNode node)
        {
            var leftNode = node.Left;
            var rightNode = node.Left?.Right;
            leftNode.Right = node;
            node.Left = rightNode;
            return leftNode;
        }

        public void PreOrder()
        {
            PreOrder(Root);
        }

        public void PreOrder(TreeNode node)
        {
            if (node == null)
                return;

            Console.WriteLine($"value:{node.Value},color:{Enum.GetName(typeof(TreeNodeColor),node.Color)}");
            PreOrder(node.Left);
            PreOrder(node.Right); 
        }
    }

}
