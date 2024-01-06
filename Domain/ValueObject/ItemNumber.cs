using Domain.Exception;
using Domain.ValueObject.Base;

namespace Domain.ValueObject;

public sealed class ItemNumber : ValueObjectBase
{
    private const int Min = 1;

    private const int Max = 20;
    
    public int Value;
    
    private ItemNumber(int value)
    {
        Value = value;
    }

    public static ItemNumber FromValue(int value)
    {
        if (value < Min)
        {
            throw new PaginatorException("Page cannot be less than 1!");
        }

        if (value > Max)
        {
            throw new PaginatorException("Page cannto be more than 20!");
        }
        
        return new ItemNumber(value);
    }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}