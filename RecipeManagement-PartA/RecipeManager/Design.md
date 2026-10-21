# Design

## 1. Saved recipe collection

I selected a `HashSet<int>` to store saved recipe IDs. It prevents duplicate IDs automatically: `Add` returns `false` when an ID is already saved. `Remove` cancels a saved recipe, and `Contains` checks whether a recipe is saved.

Before adding an ID, `AddSavedRecipe` checks that it exists in the recipe dictionary. The saved feature does not require a particular output order. `GetSavedRecipes` returns a list copy so callers cannot change the internal collection through the returned list.

## 2. Integration

The Part B features are implemented in the existing `RecipeManager`. Title search, ingredient search and the protein report use LINQ over the same recipe dictionary created in Part A. The saved collection stores recipe IDs from this catalogue. The existing `IRecipeManager` method signatures are retained for the application and tests. The integration test searches for a recipe, saves the search result, cancels the saved recipe and checks that the recipe remains in the catalogue.

## 3. Basic complexity

| Operation | Structure | Expected complexity | Reason |
| --- | --- | --- | --- |
| Lookup recipe by ID | Dictionary | Average O(1) | Hash-based key lookup locates the recipe by its ID. |
| Traverse cooking plan | LinkedList | O(n) | Each planned recipe may need to be visited. |
| Complete next instruction | Queue | O(1) | Dequeue removes the instruction at the front. |
| LINQ title/ingredient search | Recipe collection | O(n) | Each recipe may need to be inspected. |
| Check whether a recipe is saved | HashSet<int> | Average O(1) | Contains uses a hash-based lookup of the recipe ID. |

For cooking-plan traversal, n is the number of planned recipes. For searching, n is the number of recipes in the catalogue.

The O(n) search estimate treats the text checked per recipe as bounded. Actual search time also depends on text length and, for ingredient search, the number of ingredient strings.
