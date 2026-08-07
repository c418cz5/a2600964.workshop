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

### Topic 2: (TBD)

- To be updated.

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
