using System;
using System.Collections.Generic;
using System.Text;

namespace Iterators
{
    public class Node
    {
        public int SucceededSales { get; set; }

        public List<Node> Childs { get; set; }

        public bool IsVisited { get; set; }

        public Node()
        {
            SucceededSales = new Random().Next(0, 100);
            Childs = new List<Node>();
            IsVisited = false;
        }

        public void GenerateChilds()
        {
            var childsNum = new Random().Next(2, 10);
            for (int i = 2; i <= childsNum; i++)
            {
                Childs.Add(new Node());
            }
        }

        public void Reset()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(this);
            Node node;

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                node.IsVisited = false;

                if (node.Childs.Count > 0)
                    foreach (var ch in node.Childs)
                        if (ch.IsVisited)
                            queue.Enqueue(ch);
            }
        }
    }
}
