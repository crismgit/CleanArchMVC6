using CleanArchMvc6.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMvc6.Application.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
