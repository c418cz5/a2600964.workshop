using System.Collections.Generic;
using RecipeManagement.Core;
using Xunit;

namespace RecipeManagement.Tests;

/// <summary>
/// Example tests from the assignment specification. Add your own tests as you work.
/// </summary>
public sealed class RecipeManagerTests
{
    [Fact]
    public void Constructor_BuildsRecipeDictionary()
    {
        var manager = CreateManager();

        Assert.Equal(2, manager.RecipeCount);
        Assert.Equal("Recipe A", manager.FindRecipe(10)?.Title);
    }

    [Fact]
    public void InstructionsAreCompletedInFileOrder()
    {
        var manager = CreateManager();

        Assert.True(manager.StartCooking(10));
        Assert.Equal("First step", manager.PeekNextInstruction());
        Assert.Equal("First step", manager.CompleteNextInstruction());
        Assert.Equal("Second step", manager.PeekNextInstruction());
    }

    [Fact]
    public void RemovedRecipesAreRestoredLastInFirstOut()
    {
        var manager = CreateManager();

        manager.AddRecipeToCookingPlan(10);
        manager.AddRecipeToCookingPlan(20);

        manager.RemoveRecipeFromCookingPlan(10);
        manager.RemoveRecipeFromCookingPlan(20);

        Assert.Equal(20, manager.PeekLastRemovedRecipe());
        Assert.True(manager.RestoreLastRemovedRecipe());
        Assert.Equal(new[] { 20 }, manager.GetCookingPlan());
    }

    [Fact]
    public void AddRecipe_NewValidRecipe_ReturnsTrue_IncreasesCount_CanFind()
    {
        var initialRecipes = new List<Recipe>();
        var manager = new RecipeManager(initialRecipes);

        var newRecipe = new Recipe
        {
            Id = 10,
            Title = "Test Soup",
            Ingredients = new List<string>(),
            Instructions = new List<string>()
        };

        bool result = manager.AddRecipe(newRecipe);

        Assert.True(result);
        Assert.Equal(1, manager.RecipeCount);

        Recipe? found = manager.FindRecipe(10);

        Assert.NotNull(found);
        Assert.Equal(10, found.Id);
        Assert.Equal("Test Soup", found.Title);
    }

    [Fact]
    public void AddRecipe_DuplicateId_ReturnsFalse_CountUnchanged()
    {
        var existing = new Recipe
        {
            Id = 20,
            Title = "Pasta",
            Ingredients = new List<string>(),
            Instructions = new List<string>()
        };

        var initialRecipes = new List<Recipe> { existing };
        var manager = new RecipeManager(initialRecipes);

        int originalCount = manager.RecipeCount;

        var duplicateRecipe = new Recipe
        {
            Id = 20,
            Title = "Another Pasta",
            Ingredients = new List<string>(),
            Instructions = new List<string>()
        };

        bool result = manager.AddRecipe(duplicateRecipe);

        Assert.False(result);
        Assert.Equal(originalCount, manager.RecipeCount);
    }

    [Fact]
    public void AddIngredientsToShoppingList_AddsIngredientsInOrder()
    {
        var recipe = new Recipe
        {
            Id = 30,
            Title = "Fruit Salad",
            Ingredients = new List<string>
            {
                "1 apple",
                "2 bananas",
                "1 orange"
            },
            Instructions = new List<string>()
        };

        var manager = new RecipeManager(new[] { recipe });

        int added = manager.AddIngredientsToShoppingList(30);

        Assert.Equal(3, added);
        Assert.Equal(3, manager.ShoppingItemCount);

        Assert.Equal(
            new[] { "1 apple", "2 bananas", "1 orange" },
            manager.GetShoppingList());
    }

    [Fact]
    public void AddIngredientsToShoppingList_MissingRecipe_ReturnsZero()
    {
        var manager = CreateManager();

        int added = manager.AddIngredientsToShoppingList(999);

        Assert.Equal(0, added);
        Assert.Equal(0, manager.ShoppingItemCount);
    }

    [Fact]
    public void ClearShoppingList_RemovesAllItems()
    {
        var manager = CreateManager();

        manager.AddIngredientsToShoppingList(10);

        Assert.Equal(1, manager.ShoppingItemCount);

        manager.ClearShoppingList();

        Assert.Equal(0, manager.ShoppingItemCount);
        Assert.Empty(manager.GetShoppingList());
    }

    [Fact]
    public void GetShoppingList_ReturnsCopyOfShoppingList()
    {
        var manager = CreateManager();

        manager.AddIngredientsToShoppingList(10);

        IReadOnlyList<string> result = manager.GetShoppingList();

        var copy = Assert.IsType<List<string>>(result);

        copy.Add("extra ingredient");

        Assert.Equal(1, manager.ShoppingItemCount);
        Assert.Equal(new[] { "1 apple" }, manager.GetShoppingList());
    }

    [Fact]
    public void EmptyRemovedHistory_ReturnsFalse()
    {
        var manager = CreateManager();

        Assert.False(manager.RestoreLastRemovedRecipe());
        Assert.Null(manager.PeekLastRemovedRecipe());
    }

    [Fact]
    public void EmptyInstructionQueue_ReturnsNull()
    {
        var manager = CreateManager();

        Assert.Null(manager.PeekNextInstruction());
        Assert.Null(manager.CompleteNextInstruction());
    }

    [Fact]
    public void AddRecipeToCookingPlan_DuplicateRecipe_ReturnsFalse()
    {
        var manager = CreateManager();

        Assert.True(manager.AddRecipeToCookingPlan(10));
        Assert.False(manager.AddRecipeToCookingPlan(10));

        Assert.Equal(1, manager.CookingPlanCount);
    }

    [Fact]
    public void FindRecipe_MissingId_ReturnsNull()
    {
        var manager = CreateManager();

        Assert.Null(manager.FindRecipe(999));
    }

    [Fact]
    public void RemoveRecipe_ExistingRecipe_ReturnsTrue()
    {
        var manager = CreateManager();

        bool result = manager.RemoveRecipe(10);

        Assert.True(result);
        Assert.Equal(1, manager.RecipeCount);
        Assert.Null(manager.FindRecipe(10));
    }

    [Fact]
    public void RemoveRecipe_PlannedRecipe_ReturnsFalse()
    {
        var manager = CreateManager();

        manager.AddRecipeToCookingPlan(10);

        Assert.False(manager.RemoveRecipe(10));
        Assert.Equal(2, manager.RecipeCount);
        Assert.NotNull(manager.FindRecipe(10));
    }

    [Fact]
    public void RemoveRecipeFromCookingPlan_UnplannedRecipe_DoesNotChangeHistory()
    {
        var manager = CreateManager();

        Assert.False(manager.RemoveRecipeFromCookingPlan(10));
        Assert.Equal(0, manager.RemovedRecipeCount);
        Assert.Null(manager.PeekLastRemovedRecipe());
    }

    [Fact]
    public void SearchByTitle_PartialText_IgnoresCase()
    {
        var manager = CreateManager();

        IReadOnlyList<Recipe> results = manager.SearchByTitle("CIPE A");

        Recipe recipe = Assert.Single(results);
        Assert.Equal(10, recipe.Id);
    }

    [Fact]
    public void SearchByTitle_NoMatch_ReturnsEmpty()
    {
        var manager = CreateManager();

        IReadOnlyList<Recipe> results = manager.SearchByTitle("Soup");

        Assert.Empty(results);
    }

    [Fact]
    public void SearchByTitle_BlankText_ReturnsAllRecipes()
    {
        var manager = CreateManager();

        IReadOnlyList<Recipe> results = manager.SearchByTitle("   ");

        Assert.Equal(2, results.Count);
        Assert.Contains(results, recipe => recipe.Id == 10);
        Assert.Contains(results, recipe => recipe.Id == 20);
    }

    [Fact]
    public void SearchByIngredient_PartialText_IgnoresCase()
    {
        var manager = CreateManager();

        IReadOnlyList<Recipe> results = manager.SearchByIngredient("PPL");

        Recipe recipe = Assert.Single(results);
        Assert.Equal(10, recipe.Id);
    }

    [Fact]
    public void SearchByIngredient_NoMatch_ReturnsEmpty()
    {
        var manager = CreateManager();

        IReadOnlyList<Recipe> results = manager.SearchByIngredient("chicken");

        Assert.Empty(results);
    }

    [Fact]
    public void SearchByIngredient_MultipleMatchingIngredients_ReturnsRecipeOnce()
    {
        var recipe = new Recipe
        {
            Id = 30,
            Title = "Apple Dessert",
            Ingredients = new List<string>
            {
                "1 apple",
                "100 ml apple juice"
            }
        };

        var manager = new RecipeManager(new[] { recipe });

        IReadOnlyList<Recipe> results = manager.SearchByIngredient("apple");

        Recipe found = Assert.Single(results);
        Assert.Equal(30, found.Id);
    }

    [Fact]
    public void GetHighestProteinRecipes_ReturnsHighestInDescendingOrder()
    {
        var manager = CreateProteinManager();

        IReadOnlyList<Recipe> results = manager.GetHighestProteinRecipes(2);

        Assert.Equal(2, results.Count);
        Assert.Equal(20, results[0].Id);
        Assert.Equal(10, results[1].Id);
    }

    [Fact]
    public void GetHighestProteinRecipes_MissingData_ReturnsOnlyAvailableRecipes()
    {
        var manager = CreateProteinManager();

        IReadOnlyList<Recipe> results = manager.GetHighestProteinRecipes(10);

        Assert.Equal(3, results.Count);
        Assert.Equal(20, results[0].Id);
        Assert.Equal(10, results[1].Id);
        Assert.Equal(30, results[2].Id);
    }

    [Fact]
    public void GetHighestProteinRecipes_NonPositiveCount_ReturnsEmpty()
    {
        var manager = CreateProteinManager();

        Assert.Empty(manager.GetHighestProteinRecipes(0));
        Assert.Empty(manager.GetHighestProteinRecipes(-1));
    }

    [Fact]
    public void AddSavedRecipe_ExistingRecipes_SavesIds()
    {
        var manager = CreateManager();

        Assert.False(manager.IsRecipeSaved(10));

        Assert.True(manager.AddSavedRecipe(10));
        Assert.True(manager.AddSavedRecipe(20));

        Assert.True(manager.IsRecipeSaved(10));
        Assert.True(manager.IsRecipeSaved(20));

        IReadOnlyList<int> saved = manager.GetSavedRecipes();

        Assert.Equal(2, saved.Count);
        Assert.Contains(10, saved);
        Assert.Contains(20, saved);
    }

    [Fact]
    public void AddSavedRecipe_DuplicateId_ReturnsFalse()
    {
        var manager = CreateManager();

        Assert.True(manager.AddSavedRecipe(10));
        Assert.False(manager.AddSavedRecipe(10));

        Assert.Equal(10, Assert.Single(manager.GetSavedRecipes()));
    }

    [Fact]
    public void AddSavedRecipe_MissingId_ReturnsFalse()
    {
        var manager = CreateManager();

        Assert.True(manager.AddSavedRecipe(10));
        Assert.False(manager.AddSavedRecipe(999));

        Assert.False(manager.IsRecipeSaved(999));
        Assert.Equal(10, Assert.Single(manager.GetSavedRecipes()));
    }

    [Fact]
    public void RemoveSavedRecipe_SavedRecipe_UpdatesSavedRecipes()
    {
        var manager = CreateManager();

        Assert.True(manager.AddSavedRecipe(10));
        Assert.True(manager.AddSavedRecipe(20));

        Assert.True(manager.RemoveSavedRecipe(10));
        Assert.False(manager.RemoveSavedRecipe(10));

        Assert.False(manager.IsRecipeSaved(10));
        Assert.True(manager.IsRecipeSaved(20));
        Assert.Equal(20, Assert.Single(manager.GetSavedRecipes()));
    }

    [Fact]
    public void SearchSaveAndUnsaveRecipe_IntegratedWorkflow()
    {
        var manager = CreateManager();

        IReadOnlyList<Recipe> results = manager.SearchByTitle("CIPE A");

        Recipe recipe = Assert.Single(results);
        Assert.Equal(10, recipe.Id);

        Assert.True(manager.AddSavedRecipe(recipe.Id));
        Assert.True(manager.IsRecipeSaved(recipe.Id));
        Assert.Equal(recipe.Id, Assert.Single(manager.GetSavedRecipes()));

        Assert.True(manager.RemoveSavedRecipe(recipe.Id));
        Assert.False(manager.IsRecipeSaved(recipe.Id));
        Assert.Empty(manager.GetSavedRecipes());

        Assert.Equal(2, manager.RecipeCount);
        Assert.NotNull(manager.FindRecipe(recipe.Id));
    }

    private static RecipeManager CreateProteinManager()
    {
        return new RecipeManager(new[]
        {
            new Recipe
            {
                Id = 10,
                Title = "Soup",
                Nutrition = new NutritionInfo { ProteinG = 10 }
            },

            new Recipe
            {
                Id = 20,
                Title = "Chicken",
                Nutrition = new NutritionInfo { ProteinG = 30 }
            },

            new Recipe
            {
                Id = 30,
                Title = "Tea",
                Nutrition = new NutritionInfo { ProteinG = 0 }
            },

            new Recipe
            {
                Id = 40,
                Title = "No Nutrition",
                Nutrition = null
            },

            new Recipe
            {
                Id = 50,
                Title = "No Protein",
                Nutrition = new NutritionInfo { ProteinG = null }
            }
        });
    }

    private static RecipeManager CreateManager()
    {
        return new RecipeManager(new[]
        {
            new Recipe
            {
                Id = 10,
                Title = "Recipe A",
                Ingredients = new() { "1 apple" },
                Instructions = new() { "First step", "Second step" }
            },

            new Recipe
            {
                Id = 20,
                Title = "Recipe B"
            }
        });
    }
}