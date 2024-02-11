using Application.Product.Create;
using Carter;

namespace WebApi.EndPoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("product", async (CreateProductCommand command, ISender sender) =>
            {
                await sender.Send(command);

                return Results.Ok();
            });
        }
    }
}
