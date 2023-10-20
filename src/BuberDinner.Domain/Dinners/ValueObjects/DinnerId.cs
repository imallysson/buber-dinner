using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; private set; }

    public DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private DinnerId()
    {
    }
#pragma warning restore CS8618
}
