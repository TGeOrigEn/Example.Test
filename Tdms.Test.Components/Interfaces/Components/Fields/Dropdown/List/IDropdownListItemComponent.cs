using Empyrean.Core.Interfaces;

namespace Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List
{
    public interface IDropdownListItemComponent : IWebComponent
    {
        string GetName();

        void Click();
    }
}
