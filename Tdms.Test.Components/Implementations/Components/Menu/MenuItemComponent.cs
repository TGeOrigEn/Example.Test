using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Tdms.Api.Components.Implementations.Components.Menu
{
    public class MenuItemComponent : ApplicationComponent, IMenuItemComponent
    {
        private const string _CHECKED_ATTRIBUTE = "aria-checked";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент меню");

        private const string _DEFAULT_SELECTOR = "div[id*='item'][class^='x-menu-item x-menu-item-default']";

        private const string _CHECK_BOX_SELECTOR = "div[class*='x-menu-item-checkbox']";

        private const string _NAME_SELECTOR = "span[class*='x-menu-item-indent']";

        protected IWebComponent nameComponent;

        protected IWebComponent checkBox;

        protected MenuItemComponent()
        {
            var nameComponentDescription = new Description(_NAME_SELECTOR, "Название элемента");

            var checkBoxDescription = new Description(_CHECK_BOX_SELECTOR, "Флаг элемента");

            nameComponent = GetComponent()
                .WithDescription(nameComponentDescription)
                .Perform();

            checkBox = GetComponent()
                .WithDescription(checkBoxDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void Click() => Actions.Click();

        public string GetName() => nameComponent.Properties.GetText();

        public bool HasCheckBox() => checkBox.IsAvalable();

        public void Hover() => Actions.Hover();

        public bool IsCheck() => GetAttribute(_CHECKED_ATTRIBUTE, this).Equals("true");
    }
}
