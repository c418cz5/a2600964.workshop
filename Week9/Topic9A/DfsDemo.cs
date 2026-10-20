using System;
using System.Collections.Generic;

public class DfsDemo
{
    public static void Run(Node start, Node target)
    {
        var visited = new HashSet<Node>();
        var checkedNodes = new List<string>();
        var stacked = new Stack<Node>();
        var parents = new Dictionary<Node, Node?>();

        bool found = false;

        stacked.Push(start);
        parents[start] = null;

        while (stacked.Count > 0)
        {
            var current = stacked.Pop();

            if (visited.Contains(current))
            {
                continue;
            }

            visited.Add(current);
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

                parents[neighbour] = current;
                stacked.Push(neighbour);
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