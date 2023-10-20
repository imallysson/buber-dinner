using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Hosts.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; private set; }

    public HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(string value)
    {
        return new(Guid.Parse(value));
    }

    public static HostId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private HostId()
    {
    }
#pragma warning restore CS8618
}
