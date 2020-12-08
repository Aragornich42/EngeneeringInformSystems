using System.Collections;
using System.Collections.Generic;

namespace Iterators
{
    public class DepthIterator : IEnumerable<Node>
    {
        private Node _root;

        public DepthIterator() { }

        public DepthIterator(Node root)
        {
            _root = root;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return new DepthEnumerator(_root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

    public class DepthEnumerator : IEnumerator<Node>
    {
        private Stack<Node> _stack = new Stack<Node>();
        private Node _current;
        private Node _root;

        public DepthEnumerator()
        {
            _current = new Node();
            _root = _current;
            _stack.Push(_current);
        }

        public DepthEnumerator(Node node)
        {
            _current = node;
            _root = _current;
            _stack.Push(_current);
        }

        public object Current => _current;

        Node IEnumerator<Node>.Current => _current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_stack.Count > 0)
            {
                _current = _stack.Pop();

                if (_current.Childs.Count > 0)
                    //Важно, что я обхожу слева
                    for (int i = _current.Childs.Count - 1; i > -1; i--)
                        if (!_current.Childs[i].IsVisited)
                            _stack.Push(_current.Childs[i]);

                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _current = _root;
            _stack.Clear();
            Node node = _current;
            _stack.Push(node);

            while (_stack.Count > 0)
            {
                node = _stack.Pop();
                node.IsVisited = false;

                if (node.Childs.Count > 0)
                    foreach (var ch in node.Childs)
                        if (ch.IsVisited)
                            _stack.Push(ch);
            }
        }
    }
}
