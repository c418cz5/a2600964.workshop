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
List<string> studentNames = new List<string>();

studentNames.Add("Alice");
studentNames.Add("Ben");
studentNames.Add("Chris");
studentNames.Add("Diana");
studentNames.Add("Eric"); 
studentNames.Remove("Ben");
studentNames.Insert(1, "Brian");

studentNames.AddRange(new List<string>
{
    "Fiona",
    "George",
    "Hannah",
    "Ivy",
    "Jack",
    "Kate"
});
Console.WriteLine("Student names:");

foreach (string studentName in studentNames)
{
    Console.WriteLine(studentName);
}

string searchName = "Diana";
int foundIndex = studentNames.IndexOf(searchName);

Console.WriteLine($"{searchName} is at index {foundIndex}");

string partialName = "an";

Console.WriteLine("Names containing 'an':");

foreach (string studentName in studentNames)
{
    if (studentName.Contains(partialName))
    {
        Console.WriteLine(studentName);
    }
}
int totalNameLength = 0;

foreach (string studentName in studentNames)
{
    totalNameLength += studentName.Length;
}

Console.WriteLine($"Total length of all names: {totalNameLength}");

List<string> namesAsList = new List<string>(names);

studentNames.AddRange(namesAsList);

Console.WriteLine("After adding array names:");

foreach (string studentName in studentNames)
{
    Console.WriteLine(studentName);
}