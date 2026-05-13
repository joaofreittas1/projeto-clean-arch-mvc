using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategorie();
    Task<Category> GetById(int id);
    Task Create(Category category);
    Task Update(Category category);
    Task Delete(Category category);
}
