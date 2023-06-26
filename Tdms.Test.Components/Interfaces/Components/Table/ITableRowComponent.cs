using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.Table
{
    public interface ITableRowComponent : IApplicationComponent
    {
        IWebComponentCollectionBuilder<ITableCellComponent> GetCells();

        IWebComponentBuilder<ITableCellComponent> GetCell();
    }
}
