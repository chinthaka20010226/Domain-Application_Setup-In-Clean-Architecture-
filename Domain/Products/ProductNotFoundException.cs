namespace Domain.Products
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(ProductId id)
            : base($"The product with the id = {id.Value} was not found")
        { }
    }
}
