using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(
        List<MenuSectionCommand>? sections = null) =>
        new CreateMenuCommand(
            Constants.Host.Id.Value.ToString()!,
            Constants.Menus.Name,
            Constants.Menus.Description,
            sections ?? CreateMenuSectionCommand());

    public static List<MenuSectionCommand> CreateMenuSectionCommand(
        int sectionsCount = 1,
        List<MenuItemCommand>? items = null) =>
            Enumerable.Range(0, sectionsCount)
                .Select(index => new MenuSectionCommand(
                    Constants.Menus.SectionDescriptionFromIndex(index),
                    Constants.Menus.SectionDescriptionFromIndex(index),
                    items ?? CreateMenuItemCommand(sectionsCount)))
                .ToList();

    public static List<MenuItemCommand> CreateMenuItemCommand(int itemsCount = 1) =>
        Enumerable.Range(0, itemsCount)
            .Select(index => new MenuItemCommand(
                Constants.Menus.ItemNameFromIndex(index),
                Constants.Menus.ItemDescriptionFromIndex(index)))
            .ToList();
}
