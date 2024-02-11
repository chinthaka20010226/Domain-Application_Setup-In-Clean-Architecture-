using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product;

public record Sku
{
    private const int DefaultLength = 8;

    private Sku(string value) => Value = value;

    // init -> The init accessor indicates that this property can only be set during object initialization,
    // making the Sku class immutable after creation.
    public string Value { get; init; }

    // Sku? -> nullable
    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if(value.Length != DefaultLength)
        {
            return null;
        }
        return new Sku(value);
    }
}
