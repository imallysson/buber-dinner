using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guests.ValueObjects;

public sealed class RatingItemId : ValueObject
{
    public Guid Value { get; }

    public RatingItemId(Guid value)
    {
        Value = value;
    }

    public static RatingItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
