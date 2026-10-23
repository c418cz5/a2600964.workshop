# Recipe Management System

This is my C# assignment for Part A and Part B. I completed
RecipeManager and added tests. The recipe models, JSON loader
and console menu were provided in the starter code.

## Project files

- `RecipeManagement.Core/` — RecipeManager, models and JSON loader
- `RecipeManagement.Application/` — console menu
- `RecipeManagement.Tests/` — tests for both parts
- `data/recipes.json` — recipe data
- `Design.md` — explanation of my Part B design

## Part A

I used five collections:

- `Dictionary<int, Recipe>` to store recipes by ID
- `List<string>` for the shopping list
- `LinkedList<int>` for the cooking plan
- `Stack<int>` to store IDs removed from the cooking plan
- `Queue<string>` to follow the cooking instructions in order

## Part B

I added title and ingredient searches using LINQ. Both searches
can match part of the text and ignore upper and lower case.

The protein report lists recipes from highest to lowest protein.
Recipes without protein information are left out.

I used a `HashSet<int>` to store saved recipe IDs. It prevents
duplicates and supports adding, removing and checking saved recipes.

## How to run

Open a terminal in the folder containing `RecipeManagement.sln`.
Then run:

```powershell
dotnet build
dotnet test
dotnet run --project RecipeManagement.Application -- data/recipes.json
```

The program loads the recipe data and shows the menu.
Options 15–21 are for Part B.

## Tests

The tests check normal operations and cases such as missing IDs,
duplicates and empty collections.

They also check searches, protein sorting and saved recipes.
There is an integration test that searches for a recipe, saves it
and removes it from saved recipes. It checks that the recipe
still exists in the catalogue afterwards.

## AI acknowledgement
All testing and code functionality were completed without the use of AI.