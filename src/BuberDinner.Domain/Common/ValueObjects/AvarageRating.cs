using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class AverageRating : ValueObject
{

    public AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    public static AverageRating CreateNew(double value = 0, int numRatings = 0)
    {
        return new(value, numRatings);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
