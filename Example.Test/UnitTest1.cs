using Allure.Net.Commons;
using Example.Test.Drivers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Components.TreeView;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Implementations.Requirements.Menu;
using Tdms.Api.Components.Implementations.Requirements.TreeView;
using static Tdms.Api.Components.Interfaces.Components.TreeView.ITreeViewItemComponent;

namespace Example.Test
{
    [AllureSuite("Тесты авторизации")]
    public class AuthorizationTest : WebApplicationTest
    {
        protected override IWebDriver Driver => Chrome.Remote(Host);

        protected override string Address => "http://10.0.11.18:8081/client/";

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Артём Тисло Максимович")]
        [AllureName("Успешная авторизация")]
        public void AuthorizationSuccessTest()
        {
            LogIn("SYSADMIN", string.Empty);

            var buttonRequirement = new ButtonRequirement<ButtonComponent>()
                .HasName()
                .And()
                .ByNameEquality("ОБЪЕКТЫ")
                .Perform();

            GetLoad().Perform().Wait(TimeSpan.FromSeconds(1));

            var button = Context
                .GetComponent<ButtonComponent>()
                .WithRequirement(buttonRequirement)
                .Perform();

            button.Click();

            var expandabilityRequirement = new TreeViewItemRequirement<TreeViewItemComponent>()
                .IsDisplayed()
                .And()
                .IsExpandable()
                .And()
                .IsExpanded(false)
                .And()
                .ByNameEquality("Наша организация")
                .Perform();

            var itemRequirement = new TreeViewItemRequirement<TreeViewItemComponent>()
                .IsDisplayed()
                .And()
                .IsExpandable()
                .And()
                .IsExpanded(false)
                .And()
                .ByNameContent("Каб. № 142 (эт. № 222)")
                .Perform();

            var expandabilityItem = Context
                .GetComponent<TreeViewItemComponent>()
                .WithRequirement(expandabilityRequirement)
                .Perform();

            var item = Context
                .GetComponent<TreeViewItemComponent>()
                .WithRequirement(itemRequirement)
                .Perform();

            expandabilityItem.Expand(ExpandVariant.ClickOnExpandButton);

            item.Actions.ContextClick();

            var menuItemRequirement = new MenuItemRequirement()
                .ByNameEquality("Обновить")
                .Perform();

            var menuItem = GetMenu(0).GetItem().WithRequirement(menuItemRequirement).Perform();

            menuItem.Click();

            LogOut();
        }
    }
}