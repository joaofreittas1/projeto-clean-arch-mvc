using CleanArch.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;


namespace CleanArch.Domain.Tests;

public  class ProductUnitTest
{
    [Fact]
    public void Create_Product_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product name", "Product description", 10.0m, 5, "product image");

        action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void Create_Product_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product name", "Product description", 10.0m, 5, "product image");

        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O Id do produto deve ser maior que zero");
    }

    [Fact]
    public void Create_Product_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Pr", "Product description", 10.0m, 5, "product image");

        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O nome do produto deve conter no mínimo 3 caracteres");
    }

    [Fact]
    public void Create_Product_LongImageName_DomainExceptionLongImageName()
    {
        Action action = () => new Product(1, "Product name", "Product description", 10.0m, 5, "iamgeeeeeeeeeeeeeeededededeededeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeedededeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");

        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O nome da imagem do produto deve conter no máximo 100 caracteres");
    }

    [Fact]
    public void Create_Product_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product name", "Product description", 10.0m, 5, null);
        action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void Create_Product_WithEmptyImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product name", "Product description", 10.0m, 5, string.Empty);
        action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void Create_Product_InvalidPriceValue_ExceptionDomainNegativeValue()
    {
        Action action = () => new Product(1, "Product name", "Product description", -10.0m, 5, "product image");
        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O preço do produto não pode ser negativo");
    }

    [Theory]
    [InlineData(-10)]
    public void Create_Product_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(1, "Product name", "Product description", 10.0m, value, "product image");
        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O estoque do produto não pode ser negativo");
    }
}
