using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CleanArch.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        ValidateName(name);
        
    }

    public Category(int id, string name) 
    {
        DomainExceptionValidation.When(id < 0, "O Id da categoria deve ser maior que zero");

        Id = id;
        ValidateName(name);
    }

    public ICollection<Product> Products { get; set; }
    
    private void ValidateName(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome da categoria não pode ser vazio");

        DomainExceptionValidation.When(name.Length < 3, "O nome da categoria deve conter no mínimo 3 caracteres");

        Name = name;
    }

    private void Update(string name) 
    {
        ValidateName(name);
    }
}
