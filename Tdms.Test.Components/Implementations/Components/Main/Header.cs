using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Components.Menu;
using Tdms.Api.Components.Implementations.Components.Search;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Interfaces.Components.Buttons;
using Tdms.Api.Components.Interfaces.Components.Menu;
using Tdms.Api.Components.Interfaces.Components.Search;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class Header : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Заголовок приложения");

        private const string _DEFAULT_SELECTOR = "div[id='mainView_header']";

        public virtual ISearchComponent Search { get; }

        protected IButtonComponent notificationsButton;

        protected IButtonComponent settingsButton;

        protected IButtonComponent desktopButton;

        protected IButtonComponent objectsButton;

        protected IButtonComponent mailButton;

        protected Header()
        {
            var buttonRequirement = new ButtonRequirement<ButtonComponent>();

            var notificationsRequirement = buttonRequirement.HasTip().And().ByTipEquality("Уведомления").Perform();
            var settingsRequirement = buttonRequirement.HasTip().And().ByTipEquality("Настройки").Perform();
            var desktopRequirement = buttonRequirement.HasTip().And().ByTipEquality("Рабочий стол").Perform();
            var objectsRequirement = buttonRequirement.HasTip().And().ByTipEquality("Объекты").Perform();
            var mailRequirement = buttonRequirement.HasTip().And().ByTipEquality("Почта").Perform();

            notificationsButton = GetComponent<ButtonComponent>().WithRequirement(notificationsRequirement).Perform();
            settingsButton = GetComponent<ButtonComponent>().WithRequirement(settingsRequirement).Perform();
            desktopButton = GetComponent<ButtonComponent>().WithRequirement(desktopRequirement).Perform();
            objectsButton = GetComponent<ButtonComponent>().WithRequirement(objectsRequirement).Perform();
            mailButton = GetComponent<ButtonComponent>().WithRequirement(mailRequirement).Perform();

            Search = GetComponent<SearchComponent>().Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void GoToDesktop() => desktopButton.Click();

        public void GoToObjects() => objectsButton.Click();

        public IMenuComponent GoToSettings()
        {
            settingsButton.Click();
            return IWebComponent.Context.GetComponent<MenuComponent>().Perform();
        }
    }
}
