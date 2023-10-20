using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviews.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; private set; }

    public MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private MenuReviewId()
    {
    }
#pragma warning restore CS8618
}
