using CleanArchMvc6.Application.Products.Queries;
using CleanArchMvc6.Domain.Entities;
using CleanArchMvc6.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc6.Application.Products.Handlers;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        return await _productRepository.GetProductsAsync();
    }
}
