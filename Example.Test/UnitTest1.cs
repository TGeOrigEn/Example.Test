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

            WebComponent.DEFAULT_DRIVER = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), opts);
            WebComponent.DEFAULT_TIMEOUT = TimeSpan.FromSeconds(10);
            WebComponent.DEFAULT_ACTIONS = (component, driver) => new Actions(component, driver);

            WebComponent.DEFAULT_DRIVER.Navigate().GoToUrl("http://10.0.11.18:8081/client/");
        }

        [Test]
        public void Req()
        {
            var requirement = new WebComponentRequirement();

            var a = requirement.IsAvalable();
            var b = requirement.IsDisplayed();
            var c = requirement.IsEnabled();
            var d = requirement.IsReadOnly();
            var e = requirement.IsSelected();

            var ab = a.Perform().And(b.Perform());
            var abc = a.Perform().And(b.Perform()).And(c.Perform());
            var c_ab = c.And(ab.Isolate().No()).Perform();

            var a_b = a.And(b.Perform()).Perform();
            var a_b_c = a.And(b.Perform()).And(c.Perform()).Perform();
            var c__a_b = c.And(a_b.Isolate().No()).Perform();
        }

        [Test]
        public void Auth()
        {
            LogIn("SYSADMIN", string.Empty);

            GetLoad().Perform().Wait(TimeSpan.FromSeconds(5));

            var buttonRequirement = new ButtonRequirement()
                .HasText()
                .And()
                .ByTextEquality("�������")
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
                .And()
                .ByNameEquality("���� �����������")
                .Perform();

            var itemRequirement = new TreeViewItemRequirement()
                .IsDisplayed()
                .And()
                .IsExpandable()
                .And()
                .IsExpanded(false)
                .And()
                .ByNameContent("���. � 30 (��. � 74)")
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
                .ByNameEquality("��������")
                .Perform();

            var menuItem = GetMenu(0).GetItem().WithRequirement(menuItemRequirement).Perform();

            menuItem.Click();

            LogOut();
        }

        [Test]
        public void Test1()
        {
            Auth();

            var buttonRequirement = new ButtonRequirement()
                .HasText()
                .And()
                .ByTextEquality("�������")
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
            WebComponent.DEFAULT_DRIVER.Dispose();
        }
    }
}