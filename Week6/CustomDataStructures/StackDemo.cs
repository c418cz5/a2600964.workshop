using System;

namespace CustomDataStructures
{
    class StackDemo
    {
        public static void Run()
        {
            var myStack = new CustomDataStructures.Stack<int>();

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);

            Console.WriteLine($"Peek top value: {myStack.Peek()}");
            Console.WriteLine($"Pop value: {myStack.Pop()}");
            Console.WriteLine($"Peek after pop: {myStack.Peek()}");

            Console.WriteLine($"Is empty? {myStack.IsEmpty()}");

            myStack.Pop();
            myStack.Pop();
            Console.WriteLine($"Is empty? {myStack.IsEmpty()}");

            // myStack.Pop();
        }
    }
}

