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

    // init -> only set value during object initialization -> immutable
    public string Value { get; init; }

    public static Sku? Create(String Value)
    {
        if (string.IsNullOrEmpty(Value))
        {
            return null;
        }
        if(Value.Length !=  DefaultLength)
        {
            return null;
        }
        return new Sku(Value);
    }
}
