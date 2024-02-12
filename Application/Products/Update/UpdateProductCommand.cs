using Domain.Products;
using MediatR;

namespace Application.Products.Update;

public record UpdateProductCommand(
    ProductId PoductId,
    string Name,
    Sku Sku,
    string Currency,
    decimal Amount) : IRequest;
