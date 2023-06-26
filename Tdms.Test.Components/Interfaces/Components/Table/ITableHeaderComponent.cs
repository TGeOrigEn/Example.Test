using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Field.Dropdown;
using Example.Test.Interfaces.Components.Menu;

namespace Example.Test.Interfaces.Components.Table
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
