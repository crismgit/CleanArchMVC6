﻿using AutoMapper;
using CleanArchMvc6.Application.DTOs;
using CleanArchMvc6.Application.Interfaces;
using CleanArchMvc6.Domain.Entities;
using CleanArchMvc6.Domain.Interfaces;

namespace CleanArchMvc6.Application.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetCategories();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetById(int? id)
    {
        var categoryEntity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Add(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(categoryEntity);
        categoryDto.Id = categoryEntity.Id;
    }

    public async Task Update(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Update(categoryEntity);
    }

    public async Task Remove(int? id)
    {
        var categoryEntity = _categoryRepository.GetById(id).Result;
        await _categoryRepository.Remove(categoryEntity);
    }
}
