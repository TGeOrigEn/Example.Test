using Empyrean.Core.Implementations;
using Example.Test.Components.Buttons;
using Example.Test.Components.TreeView;
using Example.Test.Requirements;
using Example.Test.Requirements.Buttons;
using Example.Test.Requirements.Menu;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using static Example.Test.Components.TreeView.TreeViewItemComponent;
using Actions = Empyrean.Core.Allure.Implementations.Actions;

namespace Example.Test
{
    public class Tests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var opts = new ChromeOptions();
            opts.BrowserVersion = "latest";
            Dictionary<string, object> selenoidOptions = new Dictionary<string, object>
            {
                { "enableVNC", true },
                { "enableVideo", true }
            };

            opts.AddAdditionalOption("selenoid:options", selenoidOptions);

            WebComponent.DEFAULT_DRIVER = new RemoteWebDriver(new Uri("http://10.0.11.18:4444/wd/hub"), opts);
            WebComponent.DEFAULT_TIMEOUT = TimeSpan.FromSeconds(5);
            WebComponent.DEFAULT_ACTIONS = (component, driver) => new Actions(component, driver);
            WebComponent.DEFAULT_DRIVER.Manage().Window.Maximize();
            WebComponent.DEFAULT_DRIVER.Navigate().GoToUrl("http://10.0.11.18:8081/client/");
        }

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

            var button = WebComponent
                .FindComponent<ButtonComponent>()
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

            var expandabilityItem = WebComponent
                .FindComponent<TreeViewItemComponent>()
                .WithRequirement(expandabilityRequirement)
                .Perform();

            var item = WebComponent
                .FindComponent<TreeViewItemComponent>()
                .WithRequirement(itemRequirement)
                .Perform();

            expandabilityItem.Expand(ExpandVariant.ClickOnExpandButton);

            item.Actions.ContextClick();

            var menuItemRequirement = new MenuItemRequirement()
                .ByNameEquality("ОБНОВИТЬ")
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

            var button = WebComponent
                .FindComponent<ButtonComponent>()
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

            var item = WebComponent.FindComponent<TreeViewItemComponent>().WithRequirement(expandabilityRequirement).Perform();

            while (true)
            {
                item.Expand();
            }
        }



        [TearDown]
        public void TearDown()
        {
            WebComponent.DEFAULT_DRIVER.Quit();
            WebComponent.DEFAULT_DRIVER.Dispose();
        }
    }
}