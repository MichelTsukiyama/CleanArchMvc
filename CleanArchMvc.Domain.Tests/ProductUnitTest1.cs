using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product missing Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id");
        }

        [Fact(DisplayName = "Create Product with missing Name value")]
        public void CreateCategory_MissingNameValue_ResultDomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product with null Name value")]
        public void CreateCategory_NullNameValue_ResultDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product with short Name value")]
        public void CreateCategory_ShortNameValue_ResultDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "12", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product with missing Description value")]
        public void CreateCategory_MissingDescriptionValue_ResultDomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product with null Description value")]
        public void CreateCategory_NullDescriptionValue_ResultDomainExceptionInvaliDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product with short Description value")]
        public void CreateCategory_ShortDescriptionValue_ResultDomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "1234", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product with negative Price value")]
        public void CreateCategory_NegativePriceValue_ResultDomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product with negative Stock value")]
        public void CreateCategory_NegativeStockValue_ResultDomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -1, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product with too long Image Name value")]
        public void CreateCategory_LongImageNameValue_ResultDomainExceptionInvalidImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 9, "loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product with null Image Name value")]
        public void CreateCategory_NullImageNameValue_ResultNoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 9, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product with empty Image Name value")]
        public void CreateCategory_EmptyImageNameValue_ResultNoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 9, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
