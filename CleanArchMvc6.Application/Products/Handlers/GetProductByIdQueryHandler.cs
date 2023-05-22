using CleanArchMvc6.Application.Products.Queries;
using CleanArchMvc6.Domain.Entities;
using CleanArchMvc6.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc6.Application.Products.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;
    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request,
         CancellationToken cancellationToken)
    {
        return await _productRepository.GetByIdAsync(request.Id);
    }
}
