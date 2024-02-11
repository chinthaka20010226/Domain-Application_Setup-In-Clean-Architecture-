using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Create
{
    public record CreateProductCommand(
        string Name,
        string Sku,
        string Currency,
        string Amount) : IRequest;
}
