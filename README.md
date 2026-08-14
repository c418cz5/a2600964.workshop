# COMP2021 Workshop Portfolio

**Student:** Weiyu Liu  
**Student ID:** a2600964

Personal workshop portfolio for COMP2021 Software Development Practice.
All workshop code, exercises, and notes go here.

---

## Repository Structure

a2600964.workshop/
├── HelloCSharp/ # First C# console app, environment test
├── Prac1B/ # Topic 1 practical tasks
├── Prac1B.Tests/ # Unit tests for Prac1B
├── Prac2A/ # Payroll class and Program.cs
├── Prac2A.Tests/ # Payroll xUnit tests
└── README.md

---

## Topics

### Topic 1: C# Basics and OOP Intro

- **Status:** In progress
- **Content:** C# syntax overview, static typing, classes & objects, control flow, collections, exceptions, unit testing
- **Practical:** Todo manager console app with List and Dictionary, XUnit tests
- **Key concepts learned:**
  - C# is compiled + statically typed (vs Python dynamic)
  - CLR, IL intermediate language, garbage collection
  - Access modifiers: public / private / protected
  - Auto-properties, constructors
  - List<T>, Dictionary<TKey, TValue>
  - try-catch-finally exception handling
  - XUnit unit testing with Assert
  - Git workflow: commit frequently, .gitignore for bin/obj

---


### Topic 2: Classes, Methods and Properties

- **Status:** Complete
- **Practical:** Payroll class, properties, xUnit tests and Git reflection

#### Task 1: Refactoring to a Payroll Class

Created a Payroll class with private fields, a constructor, CalculateNetPay() and ChangeTaxRate() methods.

#### Task 2: Adding Properties

Changed the fields into properties with validation. Negative hours, rate and tax rate values are not allowed.

#### Task 3: Unit Tests

Created an xUnit test project called Prac2A.Tests. The tests cover normal calculations, tax rate changes and invalid negative values.

Payroll.cs achieved 100% line coverage and 100% branch coverage.


#### Task 4 Reflection

When I first wrote the payroll calculator, the calculations and validation were written in the main program. The code worked, but the payroll data and the program logic were in the same place.

After changing it to a Payroll class, the fields, properties and methods are kept together. The Program.cs file is now shorter because it only creates a Payroll object and calls its methods. The properties also help prevent negative hours, rate and tax rate values.

Static typing makes me specify the type of each variable, such as double and decimal. At first this feels more strict than procedural code, but it helps find mistakes when building the program. It also helped me notice the difference between double and decimal when working with payroll calculations.

---

### Topic 3: (TBD)

- To be updated.

---

## How to Run

Prerequisites: .NET SDK installed

```bash
# Run a console project
cd ProjectName
dotnet run

# Run unit tests
cd ProjectName.Tests
dotnet test


