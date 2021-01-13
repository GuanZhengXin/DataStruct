using System;
using Common.LinkNode;

namespace Common.DataStruct
{
    /// <summary>
    /// 无向图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<K, T>
    {
        public Graph(int capacity = 20)
        {
            LinkNodeArray = new Array<GraphNode>(capacity);
        }

        public class GraphNode
        {
            public GraphNode(K value)
            {
                Value = value;
            }

            public SingleLinkNode<T> LinkNode { get; set; }

            public K Value { get; set; }
        }

        private Array<GraphNode> LinkNodeArray { get; set; }

        public int GetSize()
        {
            return LinkNodeArray.GetSize();
        }

        private GraphNode GetLinkNode(int index)
        {
            if (index >= LinkNodeArray.GetSize())
                return default;

            return LinkNodeArray.Get(index);
        }

        public void AddPos(T value,params T[] values)
        {
            
        }


    }
}
