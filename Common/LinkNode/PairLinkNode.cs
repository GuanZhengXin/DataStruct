using System;
using System.Text;

namespace Common.LinkNode
{
    /// <summary>
    /// 双链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PairLinkNode<T> where T : IComparable
    {
        /// <summary>
        /// 链表长度
        /// </summary>
        private int Length { get; set; }

        /// <summary>
        /// 哨兵节点
        /// </summary>
        private Node SentryHead { get; set; }

        public PairLinkNode()
        {
            SentryHead = new Node();
        }

        private class Node
        {
            public Node()
            {
            }

            public Node(T value, Node pre = default, Node next = default)
            {
                Value = value;
                Pre = pre;
                Next = next;
            }

            public T Value { get; set; }

            public Node Pre { get; set; }

            public Node Next { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        /// <summary>
        /// 得到长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return Length;
        }

        /// <summary>
        /// 得到节点的值
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Get(int position)
        {
            if (position == 0)
                return default;

            var num = position > 0 ? position : Length - Math.Abs(position + 1);
            if (position > Length)
                throw new ArgumentException("position must greater than 0");

            var cunrrentNode = SentryHead;
            for (int i = 1; i <= num; i++)
            {
                cunrrentNode = cunrrentNode.Next;
            }
            return cunrrentNode.Value;
        }

        /// <summary>
        /// 得到中间节点的值
        /// </summary>
        /// <returns></returns>
        public T GetMidNode()
        {
            var fastNode = SentryHead;
            var slowNode = SentryHead;

            while (slowNode.Next!= null && fastNode.Next!=null && fastNode.Next.Next!=null)
            {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
            }

            if (fastNode.Next != null)
                slowNode = slowNode.Next;

            return slowNode.Value;
        }

        /// <summary>
        /// 增加一个节点到第一个位置
        /// </summary>
        /// <param name="value">node element</param>
        public void AddFirst(T value)
        {
            var newNode = new Node(value)
            {
                Next = SentryHead.Next,
                Pre = SentryHead
            };
            SentryHead.Next = newNode;
            Length++;
        }

        /// <summary>
        /// 增加一个节点到最后一个位置
        /// </summary>
        /// <param name="value">node element</param>
        public void AddLast(T value)
        {
            var newNode = new Node(value);
            var preNode = SentryHead;
            for (int i = 0; i < Length; i++)
            {
                preNode = preNode.Next;
            }
            preNode.Next = newNode;
            newNode.Pre = preNode;
            Length++;
        }

        /// <summary>
        /// 添加一个元素到指定的位置
        /// </summary>
        /// <param name="value">node element</param>
        /// <param name="position">position</param>
        public void Add(T value,int position =1)
        {
            if (position != 1)
            {
                if (position <=0)
                    throw new ArgumentException("position is must greater than 0");

                if (position > Length )
                    throw new ArgumentException("position is greater than linknode length");
            }
   
            var newNode = new Node(value);
            var preNode = SentryHead;
            for (int i = 1; i < position; i++)
            {
                preNode = preNode.Next;
            }
            newNode.Next = preNode.Next;
            newNode.Pre = preNode;
            preNode.Next = newNode;
            Length++;
        }

        /// <summary>
        /// 移除第一个元素
        /// </summary>
        public void RemoveFirst()
        {
            if (Length == 0)
                return;

            var removeNode = SentryHead.Next;
            SentryHead.Next = removeNode.Next;
            if (removeNode.Next != null)
                removeNode.Next.Pre = SentryHead;
            Length--;
        }

        /// <summary>
        /// 移除最后一个元素
        /// </summary>
        public void RemoveLast()
        {
            if (Length == 0)
                return;

            var currentNode = SentryHead;
            while (currentNode.Next!=null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Pre.Next = null;
            currentNode.Pre = null;
            Length--;
        }

        public void Remove(T value)
        {
            var currentNode = SentryHead;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                if (currentNode.Value.Equals(value))
                {
                    currentNode.Pre.Next = currentNode.Next;
                    currentNode.Next.Pre = currentNode.Pre;
                    Length--;
                }
            }
        }

        /// <summary>
        /// 删除第几个元素  正数为正序，负数为倒数。
        /// </summary>
        /// <param name="position"></param>
        public void Remove(int position)
        {
            if (position == 0)
                return;

            var num = position>0 ? position : Length - Math.Abs(position+1);
            if(position>Length)
                throw new ArgumentException("position must greater than 0");

            var cunrrentNode = SentryHead;
            for (int i = 1; i <= num; i++)
            {
                cunrrentNode = cunrrentNode.Next;
            }
            cunrrentNode.Pre.Next = cunrrentNode.Next;
            if (cunrrentNode.Next != null)
                cunrrentNode.Next.Pre = cunrrentNode.Pre;

            Length--;
        }

        public void Remove(Func<T, bool> func)
        {
            var currentNode = SentryHead;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                if (func(currentNode.Value))
                {
                    currentNode.Pre.Next = currentNode.Next;
                    currentNode.Next.Pre = currentNode.Pre;
                    Length--;
                }
            }
        }

        /// <summary>
        /// 是否包含某个元素
        /// </summary>
        /// <param name="value"></param>
        /// <returns>是否包含某个元素</returns>
        public bool IsContains(T value)
        {
            var currentNode = SentryHead;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 反转链表
        /// </summary>
        public void Reverse()
        {
            var currentNode = SentryHead;
            while (currentNode.Next!=null)
            {
                currentNode = currentNode.Next;
            }

            var newNode = currentNode;
            while (newNode.Pre!= SentryHead)
            {
                var tempNode = newNode.Pre;
                newNode.Pre = newNode.Next;
                newNode.Next = tempNode;
                newNode = tempNode;
            }
            newNode.Next = null;
            SentryHead.Next = currentNode;
        }


        /// <summary>
        /// 两个有序的链表合并
        /// </summary>
        /// <param name="pairLinkNodes"></param>
        public void MergeLinkNode(PairLinkNode<T> pairLinkNode)
        {
            var newNode = new Node();
            if (pairLinkNode.GetLength() == 0)
                return;

            if (Length == 0)
            {
                SentryHead = pairLinkNode.SentryHead;
                return;
            }

            var currentNode1 = SentryHead.Next;
            var currentNode2 = pairLinkNode.SentryHead.Next;
            var endNode = newNode;
            var sentryHead = newNode;
            while (currentNode1 !=null && currentNode2 != null)
            {
                var node = new Node();
                if (currentNode1.Value.CompareTo(currentNode2.Value) <= 0)
                {
                    node.Value = currentNode1.Value;
                    currentNode1 = currentNode1.Next;
                }
                else
                {
                    node.Value = currentNode2.Value;
                    currentNode2 = currentNode2.Next;
                }

               
                node.Pre = endNode;
                endNode.Next = node;
                endNode = node; //衔接节点
            }

            if (currentNode1.Next == null)
            {
                endNode.Next = currentNode2;
                currentNode2.Pre = endNode;
            }
            else
            {
                endNode.Next = currentNode1;
                currentNode1.Pre = endNode;
            }

            SentryHead = sentryHead;
        }

        /// <summary>
        /// 是否有环
        /// </summary>
        /// <returns></returns>
        public bool IsLoop()
        {
            var slowNode = SentryHead.Next;
            var fastNode = SentryHead.Next;
            if (slowNode == null)
                return false;

            do
            {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
                if (slowNode == fastNode)
                    return true;

               
            } while (slowNode != null && fastNode != null && slowNode.Next != null && fastNode.Next != null && fastNode.Next.Next != null);

            return false;
        }

        public override string ToString()
        {
            var nextSb = new StringBuilder();
            var preSb = new StringBuilder();
            nextSb.Append("sentryHead->");
            preSb.Append("<-sentryHead");
            var currentNode = SentryHead;
            while (currentNode.Next !=null)
            {
                currentNode = currentNode.Next;
                nextSb.Append($"{currentNode.Value}->");
                preSb.Insert(0, $"<-{currentNode.Value}");
            }
            nextSb.Append("null");
            preSb.Insert(0, "null");
            return nextSb.ToString() + " ---- " + preSb.ToString();
        }
    }
}
