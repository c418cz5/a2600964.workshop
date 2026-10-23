using System.Collections.Generic;
using System.Text;

public class Graph
{
    public List<Node> Nodes { get; set; }

    public Graph()
    {
        Nodes = new List<Node>();
    }

    public void AddEdge(Node fromNode, Node toNode, int weight)
    {
        if (!Nodes.Contains(fromNode))
        {
            Nodes.Add(fromNode);
        }

        if (!Nodes.Contains(toNode))
        {
            Nodes.Add(toNode);
        }

        fromNode.Edges.Add(toNode, weight);
        toNode.Edges.Add(fromNode, weight);
    }

    public override string ToString()
    {
        var info = new StringBuilder();

        foreach (var node in Nodes)
        {
            info.Append($"{node.Data}: ");

            foreach (var edge in node.Edges)
            {
                info.Append($"{edge.Key.Data} ({edge.Value}) ");
            }

            info.AppendLine();
        }

        return info.ToString();
    }
}
