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
