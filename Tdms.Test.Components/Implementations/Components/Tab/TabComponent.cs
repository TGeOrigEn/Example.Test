using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.TabBar;

namespace Tdms.Api.Components.Implementations.Components.Tab
{
    public class TabComponent : ApplicationComponent, ITabComponent
    {
        private const string _ACTIVE_ATTRIBUTE = "aria-selected";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Вкладка");

        private const string _DEFAULT_SELECTOR = "a[id^='tab'][class^='x-tab'][role='tab']";

        private const string _NAME_SELECTOR = "span[class='x-tab-inner x-tab-inner-default']";

        private const string _CLOSE_BUTTON_SELECTOR = "span[id*='close'][class*='x-tab-close-btn']";

        protected IWebComponent nameComponent;

        protected IWebComponent closeButton;

        protected TabComponent()
        {
            var nameDescription = new Description(_NAME_SELECTOR, "Имя вкладки");

            var closeButtonDescription = new Description(_CLOSE_BUTTON_SELECTOR, "Кнопка 'Закрыть'");

            nameComponent = GetComponent()
                .WithDescription(nameDescription)
                .Perform();

            closeButton = GetComponent()
                .WithDescription(closeButtonDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Click() => Actions.Click();

        public virtual void Close() => closeButton.Actions.Click();

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual bool IsActive() => GetAttribute(_ACTIVE_ATTRIBUTE, this).Equals(true);
    }
}
