using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }  
    public int Stock { get; private set; }
    public string? Image { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string? image)
    {
        ValidationDomain(name, description, price, stock, image);
    }

    public Product(int id,string name, string description, decimal price, int stock, string? image)
    {
        DomainExceptionValidation.When(id < 0, "O Id do produto deve ser maior que zero");
        ValidationDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string? image, int categoryId)
    {
        ValidationDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    public void ValidationDomain(string name, string description, decimal price, int stock, string? image) 
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome do produto não pode ser vazio");
        DomainExceptionValidation.When(name.Length < 3, "O nome do produto deve conter no mínimo 3 caracteres");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "A descrição do produto não pode ser vazia");
        DomainExceptionValidation.When(description.Length < 5, "A descrição do produto deve conter no mínimo 5 caracteres");
        DomainExceptionValidation.When(price < 0, "O preço do produto não pode ser negativo");
        DomainExceptionValidation.When(stock < 0, "O estoque do produto não pode ser negativo");
        DomainExceptionValidation.When(image != null && image.Length > 100, "O nome da imagem do produto deve conter no máximo 100 caracteres");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}
