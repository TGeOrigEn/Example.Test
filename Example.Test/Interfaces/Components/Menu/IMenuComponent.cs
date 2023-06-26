using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.Menu
{
    public interface IMenuComponent : IApplicationComponent
    {
        IWebComponentCollectionBuilder<TComponent> GetItems<TComponent>() where TComponent : IMenuItemComponent;

        IWebComponentBuilder<TComponent> GetItem<TComponent>() where TComponent : IMenuItemComponent;

        IWebComponentCollectionBuilder<IMenuItemComponent> GetItems();

        IWebComponentBuilder<IMenuItemComponent> GetItem();
    }
}
