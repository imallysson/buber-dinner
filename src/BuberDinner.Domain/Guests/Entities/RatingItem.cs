using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;

namespace BuberDinner.Domain.Guests.Entities;

public sealed class RatingItem : Entity<RatingItemId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private RatingItem(
        RatingItemId ratingItemId,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(ratingItemId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static RatingItem Create(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating)
    {
        return new(
            RatingItemId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
