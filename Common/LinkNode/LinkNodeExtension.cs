using System;

namespace Common.LinkNode
{
    public static class LinkNodeExtension
    {
        /// <summary>
        /// 单链表反转
        /// </summary>
        public static void ReverseSingleLinkNode()
        {
            var linkNode = new SingleLinkNode<int>();
            for (int i = 1; i < 10; i++)
            {
                linkNode.AddLast(i);
            }

            linkNode.Reverse();
            Console.WriteLine(linkNode);
        }

        /// <summary>
        /// 双链表反转
        /// </summary>
        public static void ReversePairLinkNode()
        {
            var linkNode = new PairLinkNode<int>();
            for (int i = 1; i < 10; i++)
            {
                linkNode.AddLast(i);
            }

            linkNode.Reverse();
            Console.WriteLine(linkNode);
        }


        /// <summary>
        /// 链表中环的检测
        /// </summary>
        /// <returns></returns>
        public static bool IsLoop()
        {
            return false;
        }

        /// <summary>
        /// 两个有序的链表合并
        /// </summary>
        /// <param name="pairLinkNodes"></param>
        public static void MergeLinkNode(params PairLinkNode<int>[] pairLinkNodes)
        {
            
        }

        /// <summary>
        /// 求链表的中间结点
        /// </summary>
        public static void GetMidNode()
        {
            var linkNode = new SingleLinkNode<int>();
            for (int i = 1; i < 10; i++)
            {
                linkNode.AddLast(i);
            }


        }
    }
}
