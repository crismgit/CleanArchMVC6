using AutoMapper;
using CleanArchMvc6.Application.DTOs;
using CleanArchMvc6.Application.Products.Commands;

namespace CleanArchMvc6.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
    }
}
