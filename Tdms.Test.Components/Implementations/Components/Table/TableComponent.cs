using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Implementations.Components.Table
{
    public class TableComponent : ApplicationComponent, ITableComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Таблица");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsContent']" /*"div[id^='gridview'][class*='x-fit-item'][style*='overflow: hidden']"*/;

        protected TableComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<TComponent> GetHeader<TComponent>() where TComponent : ITableHeaderComponent =>
            GetComponent<TComponent>();

        public IWebComponentBuilder<ITableHeaderComponent> GetHeader() =>
            GetComponent<ITableHeaderComponent>(typeof(TableHeaderComponent));

        public IWebComponentCollectionBuilder<TComponent> GetHeaders<TComponent>() where TComponent : ITableHeaderComponent =>
            GetComponents<TComponent>();

        public IWebComponentCollectionBuilder<ITableHeaderComponent> GetHeaders() =>
            GetComponents<ITableHeaderComponent>(typeof(TableHeaderComponent));

        public IWebComponentBuilder<TComponent> GetRow<TComponent>() where TComponent : ITableRowComponent =>
            GetComponent<TComponent>();

        public IWebComponentBuilder<ITableRowComponent> GetRow() =>
            GetComponent<ITableRowComponent>(typeof(TableRowComponent));

        public IWebComponentCollectionBuilder<TComponent> GetRows<TComponent>() where TComponent : ITableRowComponent =>
            GetComponents<TComponent>();

        public IWebComponentCollectionBuilder<ITableRowComponent> GetRows() =>
            GetComponents<ITableRowComponent>(typeof(TableRowComponent));
    }
}
