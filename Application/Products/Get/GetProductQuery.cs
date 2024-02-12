using Domain.Products;
using MediatR;

namespace Application.Products.Get
{
    public record GetProductCommand(ProductId productId) : IRequest<ProductResponse>;

    public record ProductResponse(
        Guid Id,
        string Name,
        string Sku,
        string Currency,
        string Amount);
}
