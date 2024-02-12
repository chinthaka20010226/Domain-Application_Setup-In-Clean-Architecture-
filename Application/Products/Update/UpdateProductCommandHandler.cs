using Application.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Update
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetByIdAsync(request.ProductId);

            if(product is null)
            {
                throw new ProductNotFoundException(request.ProductId);
            }

            product.Update(
                request.Name,
                new Money(request.Currency, request.Amount),
                Sku.Create(request.Sku)!);

            _repository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
