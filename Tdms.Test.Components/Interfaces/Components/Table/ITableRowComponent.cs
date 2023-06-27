using Empyrean.Core.Interfaces;

namespace Tdms.Api.Components.Interfaces.Components.Table
{
    public interface ITableRowComponent : IApplicationComponent
    {
        IWebComponentCollectionBuilder<ITableCellComponent> GetCells();

        IWebComponentBuilder<ITableCellComponent> GetCell();

        void ContextClick();

        void Click();  
    }
}
