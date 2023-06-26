using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.TreeView;

namespace Example.Test.Interfaces.Components.Field.Dropdown.List
{
    public interface IDropdownListComponent : IWebComponent
    {
        IWebComponentCollectionBuilder<TComponent> GetItems<TComponent>() where TComponent : IDropdownListItemComponent;

        IWebComponentBuilder<TComponent> GetItem<TComponent>() where TComponent : IDropdownListItemComponent;

        IWebComponentCollectionBuilder<IDropdownListItemComponent> GetItems();

        IWebComponentBuilder<IDropdownListItemComponent> GetItem();

        IWebComponentBuilder<ITreeViewComponent> GetTreeView();
    }
}
