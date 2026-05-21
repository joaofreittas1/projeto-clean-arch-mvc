using CleanArch.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Tests;

public class CategoryUnitTest
{
    [Fact]
    public void Create_Category_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category name");

        action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void Create_Category_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category name");

        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O Id da categoria deve ser maior que zero");
    }

    [Fact]
    public void Create_Category_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");

        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O nome da categoria deve conter no mínimo 3 caracteres");
    }

    [Fact]
    public void Create_Category_MissingNameValue_DomainExceptionMissingName()
    {
        Action action = () => new Category(1, "");

        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("O nome da categoria não pode ser vazio");
    }

    [Fact]
    public void Create_Category_WithNullValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);

        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }
}
