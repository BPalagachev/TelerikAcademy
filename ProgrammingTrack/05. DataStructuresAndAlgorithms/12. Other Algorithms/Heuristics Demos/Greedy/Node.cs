using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    class Node
    {
        private int value;
        public SortedSet<MyKeyValuePair> Neighbors;

        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public Node(int value)
        {
            this.value = value;
            Neighbors = new SortedSet<MyKeyValuePair>();
        }

        public void Add(Node node, int distance)
        {
            Neighbors.Add(new MyKeyValuePair(node, distance));
        }
    }
}
