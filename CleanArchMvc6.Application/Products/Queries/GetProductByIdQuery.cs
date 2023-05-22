using CleanArchMvc6.Domain.Entities;
using MediatR;

namespace CleanArchMvc6.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
