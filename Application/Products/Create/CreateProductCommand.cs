using Domain.Products;
using MediatR;

namespace Application.Products.Create;

public record CreateProductCommand(
    ProductId ProuctI,
    string Name,
    string Sku,
    string Currency,
    decimal Amount) : IRequest;


public record UpadateProductRequest(
    string Name,
    Sku Sku,
    string Currency,
    decimal Amount);