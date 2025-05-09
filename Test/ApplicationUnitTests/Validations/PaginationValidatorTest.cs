using Application.Common;
using Application.Validations;
using FluentValidation.TestHelper;

namespace Test.ApplicationUnitTests.Validations;

public class PaginationValidatorTest
{
    [Fact]
    public void Should_Have_ValidationError_When_PageIsZero()
    {
        // Arrange
        var validator = new PaginationValidator();
        var pagination = new Pagination { Page = 0, PageSize = 10 };

        // Act
        var result = validator.TestValidate(pagination);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Page);
    }

    [Fact]
    public void Should_Have_ValidationError_When_PageIsNegative()
    {
        // Arrange
        var validator = new PaginationValidator();
        var pagination = new Pagination { Page = -1, PageSize = 10 };

        // Act
        var result = validator.TestValidate(pagination);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Page);
    }

    [Fact]
    public void Should_Have_ValidationError_When_PageSizeIsZero()
    {
        // Arrange
        var validator = new PaginationValidator();
        var pagination = new Pagination { Page = 1, PageSize = 0 };

        // Act
        var result = validator.TestValidate(pagination);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PageSize);
    }

    [Fact]
    public void Should_Have_ValidationError_When_PageSizeIsNegative()
    {
        // Arrange
        var validator = new PaginationValidator();
        var pagination = new Pagination { Page = 1, PageSize = -1 };

        // Act
        var result = validator.TestValidate(pagination);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PageSize);
    }

    [Fact]
    public void Should_Have_ValidationError_When_PageSizeIsGreaterThan100()
    {
        // Arrange
        var validator = new PaginationValidator();
        var pagination = new Pagination { Page = 1, PageSize = 101 };

        // Act
        var result = validator.TestValidate(pagination);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PageSize);
    }
    
    [Fact]
    public void Should_Not_Have_ValidationError_When_PageAndPageSizeAreValid()
    {
        // Arrange
        var validator = new PaginationValidator();
        var pagination = new Pagination { Page = 1, PageSize = 10 };

        // Act
        var result = validator.TestValidate(pagination);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}