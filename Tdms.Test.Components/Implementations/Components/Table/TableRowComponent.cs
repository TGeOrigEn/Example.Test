using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Implementations.Components.Table
{
    public class TableRowComponent : ApplicationComponent, ITableRowComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Строка таблицы");

        private const string _DEFAULT_SELECTOR = "table[id^='gridview']";

        protected TableRowComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void Click() => Actions.Click();

        public void ContextClick() => Actions.ContextClick();

        public IWebComponentBuilder<ITableCellComponent> GetCell() =>
            GetComponent<ITableCellComponent>(typeof(TableCellComponent));

        public IWebComponentCollectionBuilder<ITableCellComponent> GetCells() =>
            GetComponents<ITableCellComponent>(typeof(TableCellComponent));
    }
}
