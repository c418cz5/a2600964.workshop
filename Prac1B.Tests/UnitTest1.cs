using Xunit;

public class PersonTests
{
    [Fact]
    public void FullName_ReturnsExpectedFormat()
    {
        var person = new Person("Alice", "Nguyen", 25);

        Assert.Equal("Nguyen, Alice", person.FullName());
    }

    [Fact]
    public void IsAdult_ReturnsTrue_WhenAge18OrMore()
    {
        var person = new Person("Alice", "Nguyen", 18);

        Assert.True(person.IsAdult());
    }
}