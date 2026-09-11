var names = new List<string>
{
    "Zoe",
    "Charlie",
    "Alice",
    "Brian",
    "Emily",
    "David",
    "Grace",
    "Frank",
    "Hannah",
    "Oliver"
};

Console.WriteLine("Original names:");

foreach (var name in names)
{
    Console.WriteLine(name);
}

var orderedNames = names.OrderBy(x => x);
var sortedNames = orderedNames.ToList();

Console.WriteLine("\nSorted names:");

foreach (var name in sortedNames)
{
    Console.WriteLine(name);
}