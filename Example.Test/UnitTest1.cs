using Example.Test.Components.Buttons;
using Example.Test.Components.TreeView;
using Example.Test.Drivers;
using Example.Test.Requirements;
using Example.Test.Requirements.Buttons;
using Example.Test.Requirements.Menu;
using OpenQA.Selenium;
using static Example.Test.Components.TreeView.TreeViewItemComponent;

namespace Example.Test
{
    public class Tests : WebApplicationTest
    {
        protected override IWebDriver Driver => Chrome.Remote(Host);

        protected override string Address => "http://10.0.11.18:8081/client/";

        [Test]
        public void Auth()
        {
            LogIn("SYSADMIN", string.Empty);

            var buttonRequirement = new ButtonRequirement()
                .HasText()
                .And()
                .ByTextEquality("ОБЪЕКТЫ")
                .Perform();

            GetLoad().Perform().Wait(TimeSpan.FromSeconds(5));

            var button = Context
                .GetComponent<ButtonComponent>()
                .WithRequirement(buttonRequirement)
                .Perform();

            button.Click();

            var expandabilityRequirement = new TreeViewItemRequirement()
                .IsDisplayed()
                .And()
                .IsExpandable()
                .And()
                .IsExpanded(false)
                .And()
                .ByNameEquality("Наша организация")
                .Perform();

            var itemRequirement = new TreeViewItemRequirement()
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

        [Test]
        public void Test1()
        {
            LogIn("SYSADMIN", string.Empty);

            GetLoad().Perform().Wait(TimeSpan.FromSeconds(5));

            var buttonRequirement = new ButtonRequirement()
                .HasText()
                .And()
                .ByTextEquality("ОБЪЕКТЫ")
                .Perform();

            var button = Context
                .GetComponent<ButtonComponent>()
                .WithRequirement(buttonRequirement)
                .Perform();

            button.Click();

            var expandabilityRequirement = new TreeViewItemRequirement()
                .IsDisplayed()
                .And()
                .IsExpandable()
                .And()
                .IsExpanded(false)
                .Perform();

            var item = Context.GetComponent<TreeViewItemComponent>().WithRequirement(expandabilityRequirement).Perform();

            while (true)
            {
                item.Expand();
            }
        }
    }
}