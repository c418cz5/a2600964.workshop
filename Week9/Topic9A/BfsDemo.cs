using System;
using System.Collections.Generic;

public class BfsDemo
{
    public static void Run(Node start, Node target)
    {
        var visited = new HashSet<Node>();
        var checkedNodes = new List<string>();
        var queued = new Queue<Node>();
        var parents = new Dictionary<Node, Node?>();

        bool found = false;

        queued.Enqueue(start);
        visited.Add(start);
        parents[start] = null;

        while (queued.Count > 0)
        {
            var current = queued.Dequeue();
            checkedNodes.Add(current.Data);

            if (current == target)
            {
                found = true;
                break;
            }

            foreach (var neighbour in current.Edges)
            {
                if (visited.Contains(neighbour))
                {
                    continue;
                }

                visited.Add(neighbour);
                parents[neighbour] = current;
                queued.Enqueue(neighbour);
            }
        }

        Console.WriteLine(
            "Checked: " + string.Join(" -> ", checkedNodes));

        Console.WriteLine($"Found {target.Data}: {found}");

        if (found)
        {
            var path = new List<string>();
            Node? node = target;

            while (node != null)
            {
                path.Add(node.Data);
                node = parents[node];
            }

            path.Reverse();

            Console.WriteLine(
                "Path: " + string.Join(" -> ", path));
        }
    }
}