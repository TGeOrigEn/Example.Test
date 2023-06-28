using Empyrean.Core.Interfaces;

namespace Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List
{
    public interface IDropdownListComponent : IWebComponent
    {
        IWebComponentCollectionBuilder<IDropdownListItemComponent> GetItems();

        IWebComponentBuilder<IDropdownListItemComponent> GetItem();
    }
}
