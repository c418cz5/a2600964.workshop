using System;

namespace CustomDataStructures
{
    public class Queue<T>
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

        private Node? _frontNode;
        private Node? _rearNode;

        public Queue()
        {
            _frontNode = null;
            _rearNode = null;
        }

        public void Enqueue(T value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                _frontNode = newNode;
                _rearNode = newNode;
            }
            else
            {
                _rearNode!.Next = newNode;
                _rearNode = newNode;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty, cannot perform Dequeue.");
            }
            T val = _frontNode!.Value;
            _frontNode = _frontNode!.Next;
            if (_frontNode == null)
            {
                _rearNode = null;
            }
            return val;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty, cannot perform Peek.");
            }
            return _frontNode!.Value;
        }

        public bool IsEmpty()
        {
            return _frontNode == null;
        }
    }
}
