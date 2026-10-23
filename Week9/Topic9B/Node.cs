using System.Collections.Generic;

public class Node
{
    public string Data { get; set; }
    public Dictionary<Node, int> Edges { get; set; }

    public Node(string data)
    {
        Data = data;
        Edges = new Dictionary<Node, int>();
    }
}