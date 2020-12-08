using System.Collections;
using System.Collections.Generic;

namespace Iterators
{
    public class WidthIterator : IEnumerable<Node>
    {
        private Node _root;

        public WidthIterator() { }

        public WidthIterator(Node root)
        {
            _root = root;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return new WidthEnumerator(_root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

    public class WidthEnumerator : IEnumerator<Node>
    {
        private Queue<Node> _queue = new Queue<Node>();
        private Node _current;
        private Node _root;

        public WidthEnumerator()
        {
            _current = new Node();
            _current.GenerateChilds();
            _root = _current;
            _queue.Enqueue(_current);
        }

        public WidthEnumerator(Node root)
        {
            _current = root;
            _root = _current;
            _queue.Enqueue(_current);
        }

        public object Current => _current;

        Node IEnumerator<Node>.Current => _current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_queue.Count > 0)
            {
                _current = _queue.Dequeue();
                _current.IsVisited = true;

                if (_current.Childs.Count > 0)
                    foreach (var ch in _current.Childs)
                        if (!ch.IsVisited)
                            _queue.Enqueue(ch);

                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _current = _root;
            _queue.Clear();
            Node node = _current;
            _queue.Enqueue(node);

            while (_queue.Count > 0)
            {
                node = _queue.Dequeue();
                node.IsVisited = false;

                if (node.Childs.Count > 0)
                    foreach (var ch in node.Childs)
                        if (ch.IsVisited)
                            _queue.Enqueue(ch);
            }
        }
    }
}
