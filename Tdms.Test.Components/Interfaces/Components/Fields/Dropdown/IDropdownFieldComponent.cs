using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;

namespace Tdms.Api.Components.Interfaces.Components.Field.Dropdown
{
    public interface IDropdownFieldComponent : IFieldComponent
    {
        IWebComponentBuilder<IDropdownListComponent> ShowList();
    }
}
