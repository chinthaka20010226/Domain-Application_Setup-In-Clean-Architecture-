using Application.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Delete
{
    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);

            if (product is null)
            {
                throw new ProductNotFoundException(request.ProductId);
            }

            _repository.Remove(product);

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
