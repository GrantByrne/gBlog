using Blog.Web.Models;
using Blog.Web.Validation;
using FluentAssertions;
using NUnit.Framework;

namespace Blog.Web.Tests.Unit.Validation;

public class SettingsValidatorTest
{
    [Test]
    public void Validate_WhenSettingsAreValid_ShouldReturnTrue()
    {
        // Arrange
        var settings = new Settings
        {
            BlogName = "Grant Byrne"
        };
        
        var validator = new SettingsValidator();
        
        // Act
        var result = validator.Validate(settings);
        
        // Assert
        result.IsValid.Should().BeTrue();
    }
    
    [Test]
    public void Validate_WhenBlogNameIsMissing_ShouldReturnFalse()
    {
        // Arrange
        var settings = new Settings();
        
        var validator = new SettingsValidator();
        
        // Act
        var result = validator.Validate(settings);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }
}