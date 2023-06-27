using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Implementations.Components.Table
{
    public class TableCellComponent : ApplicationComponent, ITableCellComponent
    {
        private const int _DEFAULT_STATE = -1;

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Ячейка строки");

        private const string _DEFAULT_SELECTOR = "td[class^='x-grid-cell']";

        private const string _STATE_ZERO_SELECTOR = "div[class='tdms-icn-pic tdms-icn tdms-icn-63']";

        private const string _STATE_ONE_SELECTOR = "div[class='tdms-icn-pic tdms-icn tdms-icn-30']";

        private const string _CHECK_BOX_SELECTOR = "span[class^='x-grid-checkcolumn']";

        private const string _VALUE_SELECTOR = "div[class^='x-grid-cell-inner']";

        protected IWebComponent stateZeroComponent;

        protected IWebComponent stateOneComponent;

        protected IWebComponent valueComponent;

        protected IWebComponent checkBox;

        protected TableCellComponent()
        {
            var stateZeroDescription = new Description(_STATE_ZERO_SELECTOR, "Состояние 'Ноль'");

            var stateOneDescription = new Description(_STATE_ONE_SELECTOR, "Состояние 'Один'");

            var checkBoxDescription = new Description(_CHECK_BOX_SELECTOR, "Флаг");

            var valueDescription = new Description(_VALUE_SELECTOR, "Значение");

            stateZeroComponent = GetComponent()
                .WithDescription(stateZeroDescription)
                .Perform();

            stateOneComponent = GetComponent()
                .WithDescription(stateOneDescription)
                .Perform();

            checkBox = GetComponent()
                .WithDescription(checkBoxDescription)
                .Perform();

            valueComponent = GetComponent()
                .WithDescription(valueDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void Click() => Actions.Click();

        public void DoubleClick() => Actions.DoubleClick();

        public int GetState()
        {
            if (stateZeroComponent.IsAvalable())
                return 0;
            else if (stateOneComponent.IsAvalable())
                return 1;

            return _DEFAULT_STATE;
        }

        public string GetValue() => valueComponent.Properties.GetText();

        public bool HasCheckBox() => checkBox.IsAvalable();

        public bool HasState() => GetState() != _DEFAULT_STATE;

        public bool IsCheck() => ContainsClass("checked", checkBox);

        public void ContextClick() => Actions.ContextClick();
    }
}
