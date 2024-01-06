using Domain.Exception;
using Domain.ValueObject.Base;

namespace Domain.ValueObject;

public sealed class Page : ValueObjectBase
{
    private const int Min = 1;
    
    public int Value;
    
    private Page(int value)
    {
        Value = value;
    }

    public static Page FromValue(int value)
    {
        if (value < Min)
        {
            throw new PaginatorException("Page cannot be less than 1!");
        }
        return new Page(value);
    }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}