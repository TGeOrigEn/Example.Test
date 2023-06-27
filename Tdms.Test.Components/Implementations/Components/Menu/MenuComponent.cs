using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Tdms.Api.Components.Implementations.Components.Menu
{
    public class MenuComponent : ApplicationComponent, IMenuComponent
    {
        public IWebComponentCollectionBuilder<TComponent> GetItems<TComponent>() where TComponent : IMenuItemComponent => GetComponents<TComponent>();

        public IWebComponentBuilder<TComponent> GetItem<TComponent>() where TComponent : IMenuItemComponent => GetComponent<TComponent>();

        public IWebComponentCollectionBuilder<IMenuItemComponent> GetItems() => GetComponents<IMenuItemComponent>(typeof(MenuItemComponent));

        public IWebComponentBuilder<IMenuItemComponent> GetItem() => GetComponent<IMenuItemComponent>(typeof(MenuItemComponent));
    }
}
