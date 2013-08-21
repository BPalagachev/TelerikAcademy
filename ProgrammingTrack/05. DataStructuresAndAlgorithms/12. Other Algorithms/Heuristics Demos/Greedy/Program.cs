using System;
using System.Collections.Generic;

namespace Greedy
{
    class Program
    {
        static List<Node> nodes = new List<Node>();
        static void Main(string[] args)
        {
            Node one = new Node(1);
            Node two = new Node(2);
            Node three = new Node(3);
            Node four = new Node(4);
            Node five = new Node(5);
            Node six = new Node(6);
            Node seven = new Node(7);

            one.Add(two, 5);
            one.Add(three, 3);

            two.Add(four, 99);
            two.Add(five, 8);

            three.Add(six, 7);
            three.Add(seven, 2);

            Greedy(one);

            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write("{0} ", nodes[i].Value);
            }
            Console.WriteLine();
        }

        private static void Greedy(Node node)
        {
            nodes.Add(node);

            if (node.Neighbors.Count == 0)
            {
                return;
            }

            Node next = node.Neighbors.Min.Key;
            Greedy(next);
        }
    }
}
