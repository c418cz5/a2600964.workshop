using System.Collections.Generic;

public class Node
{
    public string Data { get; set; }
    public List<Node> Edges { get; set; }

    public Node(string data)
    {
        Data = data;
        Edges = new List<Node>();
    }
}