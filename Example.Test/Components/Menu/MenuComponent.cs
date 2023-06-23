using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Example.Test.Components.Menu
{
    public class MenuComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Меню");

        private const string _DEFAULT_SELECTOR = "div[id^='menu'][class^='x-menu x-layer x-menu-default x-border-box']:not([aria-expanded='false'])";

        protected MenuComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<MenuItemComponent> GetItem() => GetComponent<MenuItemComponent>();

        public IWebComponentCollectionBuilder<MenuItemComponent> GetItems() => GetComponents<MenuItemComponent>();
    }
}
