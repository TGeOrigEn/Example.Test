using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Tdms.Api.Components.Interfaces.Components.Table
{
    public interface ITableHeaderComponent : IApplicationComponent
    {
        enum SortVariant { None, ASC, DESC }

        SortVariant GetSort();

        string GetName();

        IWebComponentBuilder<IDropdownFieldComponent> GetFilter();

        IWebComponentBuilder<IMenuComponent> ShowMenu();

        void Click();
    }
}
