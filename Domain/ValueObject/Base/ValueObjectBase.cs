namespace Domain.ValueObject.Base;


// https://www.youtube.com/watch?v=P5CRea21R2E
public abstract class ValueObjectBase : IEquatable<ValueObjectBase>
{
    public abstract IEnumerable<object> GetAtomicValues();

    private bool ValuesAreEqual(ValueObjectBase other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public bool Equals(ValueObjectBase? other)
    {
        return other is not null && ValuesAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObjectBase other && ValuesAreEqual(other);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    }
}