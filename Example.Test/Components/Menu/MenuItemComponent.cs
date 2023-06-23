using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Example.Test.Components.Menu
{
    public class MenuItemComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент меню");

        private const string _DEFAULT_SELECTOR = "div[id^='menuitem'][class^='x-menu-item x-menu-item-default']";

        private const string _NAME_COMPONENT_SELECTOR = "span[class*='x-menu-item-indent']";

        private IWebComponent _nameComponent;

        protected MenuItemComponent()
        {
            var nameComponentDescription = new Description(_NAME_COMPONENT_SELECTOR, "Имя элемента");

            _nameComponent = GetComponent()
                .WithDescription(nameComponentDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public string GetName() => _nameComponent.Properties.GetText();

        public void Click() => Actions.Click();
    }
}
