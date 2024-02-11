using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product
{
    public class Product
    {
        public Product(ProductId id, string name, Money price, Sku sku)
        {
            Id = id;
            Name = name;
            Price = price;
            Sku = sku;
        }

        public ProductId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Money Price { get; private set; }
        public Sku Sku { get; private set; }
    }
}
