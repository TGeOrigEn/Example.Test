using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Tdms.Api.Components.Interfaces.Components.Table
{
    public interface ITableHeaderComponent : IApplicationComponent
    {
        enum SortVariant { None, ASC, DESC }

        SortVariant GetSort();

        string GetName();

        IWebComponentBuilder<ITableFilterComponent> GetFilter();

        IWebComponentBuilder<IMenuComponent> ShowMenu();

        void Hover();

        void Click();
    }
}
