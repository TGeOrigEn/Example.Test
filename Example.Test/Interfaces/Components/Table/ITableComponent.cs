using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.Table
{
    public interface ITableComponent : IApplicationComponent
    {
        IWebComponentCollectionBuilder<TComponent> GetHeaders<TComponent>() where TComponent : ITableHeaderComponent;

        IWebComponentBuilder<TComponent> GetHeader<TComponent>() where TComponent : ITableHeaderComponent;

        IWebComponentCollectionBuilder<TComponent> GetRows<TComponent>() where TComponent : ITableRowComponent;

        IWebComponentBuilder<TComponent> GetRow<TComponent>() where TComponent : ITableRowComponent;

        IWebComponentCollectionBuilder<ITableHeaderComponent> GetHeaders();

        IWebComponentBuilder<ITableHeaderComponent> GetHeader();

        IWebComponentCollectionBuilder<ITableRowComponent> GetRows();

        IWebComponentBuilder<ITableRowComponent> GetRow();
    }
}
