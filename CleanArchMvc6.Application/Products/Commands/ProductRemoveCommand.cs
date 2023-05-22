﻿using CleanArchMvc6.Domain.Entities;
using MediatR;

namespace CleanArchMvc6.Application.Products.Commands;

public class ProductRemoveCommand : IRequest<Product>
{
    public int Id { get; set; }
    public ProductRemoveCommand(int id)
    {
        Id = id;
    }
}
