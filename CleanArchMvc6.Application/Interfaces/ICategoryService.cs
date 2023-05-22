using CleanArchMvc6.Application.DTOs;

namespace CleanArchMvc6.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetById(int? id);
    Task Add(CategoryDTO categoryDto);
    Task Update(CategoryDTO categoryDto);
    Task Remove(int? id);
}
