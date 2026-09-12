using System;

namespace CustomDataStructures
{
    public class Stack<T>
    {
        private class Node
        {
            public T Value;
            public Node? Next;
            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? _topNode;

        public Stack()
        {
            _topNode = null;
        }

        public void Push(T value)
        {
            Node newNode = new Node(value);
            newNode.Next = _topNode;
            _topNode = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty, cannot perform Pop.");
            }
            T val = _topNode!.Value;
            _topNode = _topNode!.Next;
            return val;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty, cannot perform Peek.");
            }
            return _topNode!.Value;
        }

        public bool IsEmpty()
        {
            return _topNode == null;
        }
    }
}
