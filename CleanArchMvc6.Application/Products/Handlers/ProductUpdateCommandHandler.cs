﻿using CleanArchMvc6.Application.Products.Commands;
using CleanArchMvc6.Domain.Entities;
using CleanArchMvc6.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc6.Application.Products.Handlers;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
{
    private readonly IProductRepository _productRepository;
    public ProductUpdateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ??
        throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Product> Handle(ProductUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            product.Update(request.Name, request.Description, request.Price,
                            request.Stock, request.Image, request.CategoryId);

            return await _productRepository.UpdateAsync(product);

        }
    }
}
