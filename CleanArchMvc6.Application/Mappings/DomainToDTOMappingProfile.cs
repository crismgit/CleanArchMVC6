using AutoMapper;
using CleanArchMvc6.Application.DTOs;
using CleanArchMvc6.Domain.Entities;

namespace CleanArchMvc6.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
