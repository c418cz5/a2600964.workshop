using System;
using System.Collections.Generic;
var numbers = new LinkedList<int>();
numbers.AddFirst(5);
numbers.AddLast(10);
numbers.AddLast(20);
numbers.AddLast(30);

LinkedListNode<int> node20 = numbers.Find(20)!;
numbers.AddBefore(node20, 15);
numbers.AddAfter(node20, 25);
numbers.AddLast(35);
numbers.AddLast(40);
numbers.AddLast(45);
numbers.AddLast(50);
numbers.Remove(25);
numbers.RemoveFirst();
numbers.RemoveLast();

LinkedListNode<int> fifthNode = numbers.First!;

for (int i = 1; i < 5; i++)
{
    fifthNode = fifthNode.Next!;
}

numbers.Remove(fifthNode);

Console.WriteLine("Final linked list:");

foreach (int number in numbers)
{
    Console.WriteLine(number);
}
List<Person> people = new List<Person>();
people.Add(new Person("Rick", "Liu", 22));
people.Add(new Person("John", "Smith", 17));
people.Add(new Person("Jane", "Doe", 25));
people.Add(new Person("Brian", "Griffin", 18));
people.Add(new Person("Lois", "Griffin", 30));
people.Add(new Person("Peter", "Griffin", 33));
people.Add(new Person("Stewie", "Griffin", 1));
people.Add(new Person("Meg", "Griffin", 20));
people.Add(new Person("Klaus", "Schmidt", 17));
people.Add(new Person("Kobe", "Bryant", 41));

LinkedList<Person> linkedPeople = ToLinkedList(people);

Console.WriteLine();
Console.WriteLine("People in linked list:");
Console.WriteLine(PrintPeople(linkedPeople));
people[0].Age = 23;
Console.WriteLine("After changing Rick's age:");
Console.WriteLine(PrintPeople(linkedPeople));
LinkedList<Person> sortedPeople = SortPeople(linkedPeople);
Console.WriteLine("Sorted people:");
Console.WriteLine(PrintPeople(sortedPeople));
static LinkedList<Person> ToLinkedList(List<Person> people)
{
    LinkedList<Person> linkedPeople = new LinkedList<Person>();

    foreach (Person person in people)
    {
        linkedPeople.AddLast(person);
    }

    return linkedPeople;
}


static string PrintPeople(LinkedList<Person> people)
{
    string output = "";

    foreach (Person person in people)
    {
        output += person.FullName + " - Age: "
            + person.Age + Environment.NewLine;
    }

    return output;
}


static LinkedList<Person> SortPeople(LinkedList<Person> people)
{
    LinkedList<Person> sortedPeople = new LinkedList<Person>();

    while (people.Count > 0)
    {
        LinkedListNode<Person> youngestPerson = people.First!;
        LinkedListNode<Person>? currentPerson = people.First;

        while (currentPerson != null)
        {
            if (currentPerson.Value.Age < youngestPerson.Value.Age)
            {
                youngestPerson = currentPerson;
            }

            currentPerson = currentPerson.Next;
        }

        sortedPeople.AddLast(youngestPerson.Value);
        people.Remove(youngestPerson);
    }

    return sortedPeople;
}