using Blog.Web.Models.Posts;
using Blog.Web.Validation;
using FluentAssertions;
using NUnit.Framework;

namespace Blog.Web.Tests.Unit.Validation;

public class PostValidatorTest
{
    [Test]
    public void Validate_WhenPostIsValid_ShouldReturnTrue()
    {
        // Arrange
        var post = new Post
        {
            Title = "Title",
            Content = "Content"
        };

        var validator = new PostValidator();

        // Act
        var result = validator.Validate(post);

        // Assert
        result.IsValid.Should().BeTrue();
    }
    
    [TestCase("Title", "")]
    [TestCase("", "Content")]
    public void Validate_WhenPostIsInvalid_ShouldReturnFalse(string title, string content)
    {
        // Arrange
        var post = new Post
        {
            Title = title,
            Content = content
        };

        var validator = new PostValidator();

        // Act
        var result = validator.Validate(post);

        // Assert
        result.IsValid.Should().BeFalse();
    }
}