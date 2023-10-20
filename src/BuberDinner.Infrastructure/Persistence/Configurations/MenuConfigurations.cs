using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(100);

        builder.OwnsOne(x => x.AverageRating);

        builder.Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.HasKey("Id", "MenuId");

            sb.Property(x => x.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            sb.Property(x => x.Name)
                .HasMaxLength(100);

            sb.Property(x => x.Description)
                .HasMaxLength(100);

            sb.OwnsMany(x => x.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner()
                    .HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey("Id", "MenuSectionId", "MenuId");

                ib.Property(x => x.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                ib.Property(x => x.Name)
                    .HasMaxLength(100);

                ib.Property(x => x.Description)
                    .HasMaxLength(100);
            });

            sb.Navigation(x => x.Items).Metadata.SetField("_items");
            sb.Navigation(x => x.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.DinnerIds, di =>
        {
            di.ToTable("MenuDinnerIds");

            di.WithOwner().HasForeignKey("MenuId");

            di.HasKey("Id");

            di.Property(x => x.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.MenuReviewIds, di =>
        {
            di.ToTable("MenuReviewIds");

            di.WithOwner().HasForeignKey("MenuId");

            di.HasKey("Id");

            di.Property(x => x.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
