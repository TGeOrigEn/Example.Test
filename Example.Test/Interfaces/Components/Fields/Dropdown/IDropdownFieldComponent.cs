using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Field.Dropdown.List;

namespace Example.Test.Interfaces.Components.Field.Dropdown
{
    public interface IDropdownFieldComponent : IFieldComponent
    {
        IWebComponentBuilder<IDropdownListComponent> ShowList();
    }
}
