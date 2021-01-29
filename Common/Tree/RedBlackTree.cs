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
        /// 得到节点个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Root = Add(Root, value);
            Root.Color = TreeNodeColor.Black;
        }

        private TreeNode Add(TreeNode node,T value)
        {
            if (node == null)
                return new TreeNode(value,default,default, TreeNodeColor.Red);

            if (node.Value.CompareTo(value) > 0)
                node.Left = Add(node.Left, value);
            else if (node.Value.CompareTo(value) < 0)
                node.Right = Add(node.Right, value);
            else
                node.Value = value;

            if (node.Right.Color == TreeNodeColor.Red && node.Left.Color != TreeNodeColor.Red)
                node = RotateLeft(node);

            if (node.Left.Color == TreeNodeColor.Red && node.Left.Left.Color == TreeNodeColor.Red)
                node = RotateRight(node);

            if (node.Left.Color == TreeNodeColor.Red && node.Right.Color == TreeNodeColor.Red)
                node = FlipColors(node);

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
            node.Right = leftNode;
            rightNode.Left = node;
            rightNode.Color = node.Color;
            node.Color = TreeNodeColor.Red;
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
            node.Left = rightNode;
            leftNode.Right = node;
            leftNode.Color = node.Color;
            node.Color = TreeNodeColor.Red;
            return leftNode;
        }

        /// <summary>
        /// 反转颜色
        /// </summary>
        /// <param name="node"></param>
        private TreeNode FlipColors(TreeNode node)
        {
            if (node == null)
                return default;

            node.Color = TreeNodeColor.Red;
            node.Left.Color = TreeNodeColor.Black;
            node.Right.Color = TreeNodeColor.Black;
            return node;
        }

    }

}
