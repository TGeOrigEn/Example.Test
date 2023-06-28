using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;

namespace Tdms.Api.Components.Interfaces.Components.Table
{
    public interface ITableFilterComponent : IApplicationComponent
    {
        string GetValue();

        void SetValue(string value);

        void SendKeys(string keys);

        void Clear();

        IWebComponentBuilder<IDropdownListComponent> ClickOnTrigger();
    }
}
