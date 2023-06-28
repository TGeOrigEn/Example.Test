using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Interfaces.Components.Buttons;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class ApplicationHeaderComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Заголовок приложения");

        private const string _DEFAULT_SELECTOR = "div[id='mainView_header']";

        protected IButtonComponent notificationsButton;

        protected IButtonComponent settingsButton;

        protected IButtonComponent desktopButton;

        protected IButtonComponent objectsButton;

        protected IButtonComponent mailButton;

        protected ApplicationHeaderComponent()
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
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void GoToDesktop() => desktopButton.Click();

        public void GoToObjects() => objectsButton.Click();
    }
}
