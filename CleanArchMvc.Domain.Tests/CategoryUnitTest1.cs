using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category with invalid Id value")]
        public void CreateCategory_WithNegativeIdValue_ResultDomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category with missing Name value")]
        public void CreateCategory_MissingNameValue_ResultDomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category with null Name value")]
        public void CreateCategory_NullNameValue_ResultDomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
    }
}
