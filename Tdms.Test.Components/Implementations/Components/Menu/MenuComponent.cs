using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Tdms.Api.Components.Implementations.Components.Menu
{
    public class MenuComponent : ApplicationComponent, IMenuComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Меню");

        private const string _DEFAULT_SELECTOR = "div[id^='menu'][class^='x-menu x-layer x-menu-default x-border-box']:not([aria-expanded='false'])";

        protected MenuComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual IWebComponentCollectionBuilder<TComponent> GetItems<TComponent>() where TComponent : IMenuItemComponent => GetComponents<TComponent>();

        public virtual IWebComponentBuilder<TComponent> GetItem<TComponent>() where TComponent : IMenuItemComponent => GetComponent<TComponent>();

        public virtual IWebComponentCollectionBuilder<IMenuItemComponent> GetItems() => GetComponents<IMenuItemComponent>(typeof(MenuItemComponent));

        public virtual IWebComponentBuilder<IMenuItemComponent> GetItem() => GetComponent<IMenuItemComponent>(typeof(MenuItemComponent));
    }
}
