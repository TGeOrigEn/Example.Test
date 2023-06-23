using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components;
using Example.Test.Components.Buttons;
using Example.Test.Components.Forms;
using Example.Test.Components.Menu;
using Example.Test.Requirements.Buttons;
using Example.Test.Requirements.Menu;
using NUnit.Allure.Core;

namespace Example.Test
{
    [AllureNUnit]
    public abstract class BaseTest
    {
        protected static MenuComponent GetMenu(int index) => WebComponent
            .FindComponent<MenuComponent>()
            .WithDescription(MenuComponent.DEFAULT_DESCRIPTION.With(index))
            .Perform();

        protected static IWebComponentBuilder<LoadIndicatorComponent> GetLoad() =>
            WebComponent.FindComponent<LoadIndicatorComponent>();

        protected static void LogOut()
        {
            var logOutRequirement = new ButtonRequirement()
                .HasTip()
                .And()
                .ByTipEquality("Настройки")
                .Perform();

            var logOutButton = WebComponent
                .FindComponent<ButtonComponent>()
                .WithRequirement(logOutRequirement)
                .Perform();

            logOutButton.Click();

            var menuComponent = WebComponent
                .FindComponent<MenuComponent>()
                .Perform();

            var menuItemRequirement = new MenuItemRequirement()
                .ByNameEquality("Выход")
                .Perform();

            var menuItem = menuComponent.GetItem()
                .WithRequirement(menuItemRequirement)
                .Perform();

            menuItem.Click();
        }

        protected static void LogIn(string username, string password) =>
            WebComponent.FindComponent<AuthorizationFormComponent>().Perform().LogIn(username, password);
    }
}
