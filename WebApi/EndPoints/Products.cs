using Application.Products.Create;
using Application.Products.Delete;
using Carter;
using Domain.Products;
using MediatR;

namespace WebApi.EndPoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("products", async (CreateProductCommand command, ISender sender) =>
            {
                await sender.Send(command);

                return Results.Ok();
            });

            app.MapPut("products/{id:giud}", async (Guid id, [FromBody] UpdateProductRequest request, ISender sender) =>
            {
                var command = new UpdateProductCommand(
                    new ProductId(id),
                    request.Name,
                    request.Sku,
                    request.Currency,
                    request.Amount);

                await sender.Send(command);

                return Results.NoContent();
            });

            app.MapDelete("products/{id:guid}", async (Guid id, ISender sender) =>
            {
                try
                {
                    await sender.Send(new DeleteProductCommand(new ProductId(id)));

                    return Results.NoContent();
                }
                catch(ProductNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }
    }
}
