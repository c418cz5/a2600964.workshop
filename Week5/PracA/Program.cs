string[] names =
{
    "Rick",
    "Morty",
    "Summer",
    "Beth",
    "Jerry",
    "Abadango",
    "Peter",
    "Leo",
    "MJ",
    "Gwen",
};
string longestName = names[0];
string shortestName = names[0];
Console.WriteLine("Before sorting:");

foreach (string name in names)
{
    Console.WriteLine(name);

    if (name.Length > longestName.Length)
    {
        longestName = name;
    }

    if (name.Length < shortestName.Length)
    {
        shortestName = name;
    }
}

Console.WriteLine($"Longest name: {longestName}");
Console.WriteLine($"Shortest name: {shortestName}");

Array.Sort(names);

Console.WriteLine("After sorting:");

foreach (string name in names)
{
    Console.WriteLine(name);
}
Console.WriteLine("Before reversing:");

foreach (string name in names)
{
    Console.WriteLine(name);
}

Array.Reverse(names);

Console.WriteLine("After reversing:");

foreach (string name in names)
{
    Console.WriteLine(name);
}