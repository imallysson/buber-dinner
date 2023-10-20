using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menus;
using Mapster;

using MenuItem = BuberDinner.Domain.Menus.Entities.MenuItem;
using MenuSection = BuberDinner.Domain.Menus.Entities.MenuSection;

namespace BuberDinner.API.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(
                dest => dest.AverageRating,
                src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : (double?)null)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());
    }
}
