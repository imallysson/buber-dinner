using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.Menus.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem>? items = null)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items ?? new();
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? items = null)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items);
    }

#pragma warning disable CS8618
    private MenuSection()
    {
    }
#pragma warning restore CS8618
}
