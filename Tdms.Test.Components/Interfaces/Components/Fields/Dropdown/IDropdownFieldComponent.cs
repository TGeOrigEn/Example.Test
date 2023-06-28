using Empyrean.Core.Interfaces;

namespace Tdms.Api.Components.Interfaces.Components.Field.Dropdown
{
    public interface IDropdownFieldComponent : IFieldComponent
    {
        IWebComponentBuilder<TComponent> ShowList<TComponent>() where TComponent : IApplicationComponent;
    }
}
