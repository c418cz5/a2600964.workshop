using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManagement.Core;

/// <summary>
/// Implement this class using the five Part A collections as private fields:
/// Dictionary&lt;int, Recipe&gt;, List&lt;string&gt;, LinkedList&lt;int&gt;,
/// Stack&lt;int&gt; and Queue&lt;string&gt;.
/// </summary>
public sealed class RecipeManager : IRecipeManager
{
    private readonly Dictionary<int, Recipe> _recipes;
    private readonly List<string> _shoppingList;
    private readonly LinkedList<int> _cookingPlan;
    private readonly Stack<int> _removedRecipes;
    private readonly Queue<string> _instructionQueue;
    private readonly HashSet<int> _savedRecipes;

    public RecipeManager(IEnumerable<Recipe> recipes)
    {
        if (recipes is null)
        {
            throw new ArgumentNullException(nameof(recipes));
        }

        _recipes = new Dictionary<int, Recipe>();
        _shoppingList = new List<string>();
        _cookingPlan = new LinkedList<int>();
        _removedRecipes = new Stack<int>();
        _instructionQueue = new Queue<string>();
        _savedRecipes = new HashSet<int>();

        foreach (Recipe recipe in recipes)
        {
            if (recipe is null)
            {
                throw new ArgumentException(
                    "Recipe collection contains a null element.",
                    nameof(recipes));
            }

            if (recipe.Id <= 0)
            {
                throw new ArgumentException(
                    $"Recipe ID must be positive, but got {recipe.Id}.",
                    nameof(recipes));
            }

            if (string.IsNullOrWhiteSpace(recipe.Title))
            {
                throw new ArgumentException(
                    $"Recipe with ID {recipe.Id} has a blank title.",
                    nameof(recipes));
            }

            if (_recipes.ContainsKey(recipe.Id))
            {
                throw new ArgumentException(
                    $"Duplicate recipe ID: {recipe.Id}.",
                    nameof(recipes));
            }

            _recipes.Add(recipe.Id, recipe);
        }
    }

    public int RecipeCount => _recipes.Count;

    public int ShoppingItemCount => _shoppingList.Count;

    public int CookingPlanCount => _cookingPlan.Count;

    public int PendingInstructionCount => _instructionQueue.Count;

    public int RemovedRecipeCount => _removedRecipes.Count;


    public Recipe? FindRecipe(int recipeId)
    {
        if (_recipes.TryGetValue(recipeId, out Recipe? recipe))
        {
            return recipe;
        }

        return null;
    }


    public bool AddRecipe(Recipe recipe)
    {
        if (recipe is null)
        {
            throw new ArgumentNullException(nameof(recipe));
        }

        if (recipe.Id <= 0)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(recipe.Title))
        {
            return false;
        }

        if (_recipes.ContainsKey(recipe.Id))
        {
            return false;
        }

        _recipes.Add(recipe.Id, recipe);
        return true;
    }


    public bool RemoveRecipe(int recipeId)
    {
        if (!_recipes.ContainsKey(recipeId))
        {
            return false;
        }

        if (_cookingPlan.Contains(recipeId))
        {
            return false;
        }

        return _recipes.Remove(recipeId);
    }


    public int AddIngredientsToShoppingList(int recipeId)
    {
        if (!_recipes.TryGetValue(recipeId, out Recipe? recipe))
        {
            return 0;
        }

        foreach (string ingredient in recipe.Ingredients)
        {
            _shoppingList.Add(ingredient);
        }

        return recipe.Ingredients.Count;
    }


    public IReadOnlyList<string> GetShoppingList()
    {
        return new List<string>(_shoppingList);
    }


    public void ClearShoppingList()
    {
        _shoppingList.Clear();
    }


    public bool AddRecipeToCookingPlan(int recipeId)
    {
        if (!_recipes.ContainsKey(recipeId))
        {
            return false;
        }

        if (_cookingPlan.Contains(recipeId))
        {
            return false;
        }

        _cookingPlan.AddLast(recipeId);
        return true;
    }


    public bool RemoveRecipeFromCookingPlan(int recipeId)
    {
        LinkedListNode<int>? node = _cookingPlan.Find(recipeId);

        if (node is null)
        {
            return false;
        }

        _cookingPlan.Remove(node);
        _removedRecipes.Push(recipeId);

        return true;
    }


    public bool RestoreLastRemovedRecipe()
    {
        if (_removedRecipes.Count == 0)
        {
            return false;
        }

        int id = _removedRecipes.Pop();

        if (_recipes.ContainsKey(id) && !_cookingPlan.Contains(id))
        {
            _cookingPlan.AddLast(id);
            return true;
        }

        return false;
    }


    public int? PeekLastRemovedRecipe()
    {
        if (_removedRecipes.TryPeek(out int value))
        {
            return value;
        }

        return null;
    }


    public IReadOnlyList<int> GetCookingPlan()
    {
        return new List<int>(_cookingPlan);
    }


    public bool StartCooking(int recipeId)
    {
        if (!_recipes.TryGetValue(recipeId, out Recipe? recipe))
        {
            return false;
        }

        if (recipe.Instructions.Count == 0)
        {
            return false;
        }

        _instructionQueue.Clear();

        foreach (string instruction in recipe.Instructions)
        {
            _instructionQueue.Enqueue(instruction);
        }

        return true;
    }


    public string? PeekNextInstruction()
    {
        if (_instructionQueue.TryPeek(out string? instruction))
        {
            return instruction;
        }

        return null;
    }


    public string? CompleteNextInstruction()
    {
        if (_instructionQueue.Count == 0)
        {
            return null;
        }

        return _instructionQueue.Dequeue();
    }


    public IReadOnlyList<Recipe> SearchByTitle(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return _recipes.Values.ToList();
        }

        return _recipes.Values
            .Where(recipe => recipe.Title.Contains(
                searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }


    public IReadOnlyList<Recipe> SearchByIngredient(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return _recipes.Values.ToList();
        }

        return _recipes.Values
            .Where(recipe => recipe.Ingredients.Any(ingredient =>
                ingredient.Contains(
                    searchText, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }


    public IReadOnlyList<Recipe> GetHighestProteinRecipes(int count)
    {
        if (count <= 0)
        {
            return new List<Recipe>();
        }

        return _recipes.Values
            .Where(recipe => recipe.Nutrition?.ProteinG != null)
            .OrderByDescending(recipe => recipe.Nutrition?.ProteinG)
            .Take(count)
            .ToList();
    }


    public bool AddSavedRecipe(int recipeId)
    {
        if (!_recipes.ContainsKey(recipeId))
        {
            return false;
        }

        return _savedRecipes.Add(recipeId);
    }


    public bool RemoveSavedRecipe(int recipeId)
    {
        return _savedRecipes.Remove(recipeId);
    }


    public bool IsRecipeSaved(int recipeId)
    {
        return _savedRecipes.Contains(recipeId);
    }


    public IReadOnlyList<int> GetSavedRecipes()
    {
        return new List<int>(_savedRecipes);
    }
}