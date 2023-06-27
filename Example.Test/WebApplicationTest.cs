using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Configurations;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Text;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Components.Form;
using Tdms.Api.Components.Implementations.Components.Loading;
using Tdms.Api.Components.Implementations.Components.Menu;
using Tdms.Api.Components.Implementations.Components.Window;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Implementations.Requirements.Menu;
using Tdms.Api.Components.Interfaces.Components.LoadIndicator;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Example.Test
{
    [AllureNUnit]
    public abstract class WebApplicationTest
    {
        protected static bool IsRemoted => (IWebComponent.Configuration.Driver as RemoteWebDriver) != null;

        protected static IContext Context => new Context();

        protected virtual TimeSpan Timeout { get; } = TimeSpan.FromSeconds(5);

        protected virtual string Host { get; } = "http://10.0.11.18:4444/";

        protected abstract IWebDriver Driver { get; }

        protected abstract string Address { get; }

        [SetUp]
        public void Setup()
        {
            IWebComponent.Configuration = new Configuration(Driver, Timeout);
            IWebComponent.Configuration.Driver.Navigate().GoToUrl(Address);
            IWebComponent.Context = Context;
            Thread.Sleep(1_000);
        }

        [TearDown]
        public void TearDown()
        {
            AddVideo();
            IWebComponent.Configuration.Driver.Dispose();
        }

        protected static void LogOut()
        {
            var logOutRequirement = new ButtonRequirement<ButtonComponent>()
                .HasTip()
                .And()
                .ByTipEquality("Настройки")
                .Perform();

            var logOutButton = IWebComponent.Context
                .GetComponent<ButtonComponent>()
                .WithRequirement(logOutRequirement)
                .Perform();

            logOutButton.Click();

            var menuComponent = IWebComponent.Context
                .GetComponent<MenuComponent>()
                .Perform();

            var menuItemRequirement = new MenuItemRequirement()
                .ByNameEquality("Выход")
                .Perform();

            var menuItem = menuComponent.GetItem()
                .WithRequirement(menuItemRequirement)
                .Perform();

            menuItem.Click();

            var messageBox = Context
                .GetComponent<MessageBoxComponent>()
                .Perform();

            messageBox.Yes();
        }

        protected static void LogIn(string username, string password) =>
            IWebComponent.Context.GetComponent<AuthorizationFormComponent>().Perform().LogIn(username, password);

        protected static IWebComponentBuilder<ILoadingComponent> GetLoad() => Context.GetComponent<ILoadingComponent>(typeof(LoadingComponent));

        protected static IMenuComponent GetMenu(int index) => Context.GetComponent<IMenuComponent>(typeof(MenuComponent))
            .WithDescription(MenuComponent.DEFAULT_DESCRIPTION.With(index))
            .Perform();

        private void AddVideo()
        {
            if (!IsRemoted)
                return;

            var allure = Allure.Net.Commons.AllureLifecycle.Instance;
            var src = $"{Host}video/{(IWebComponent.Configuration.Driver as RemoteWebDriver)?.SessionId}.mp4";
            var html = $"<html><body><video width='100%' height='100%' controls autoplay><source src='${src}' type='video/mp4'></video></body></html>";

            var content = Encoding.UTF8.GetBytes(html);
            allure.AddAttachment("Видео", "text/html", content, ".html");
        }
    }
}
