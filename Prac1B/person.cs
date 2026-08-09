using System;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person(string firstName, string lastName, int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age cannot be negative.");
        }

        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be empty.");
        }

        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string FullName()
    {
        return $"{LastName}, {FirstName}";
    }

    public bool IsAdult()
    {
        return Age >= 18;
    }
}