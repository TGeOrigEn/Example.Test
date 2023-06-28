using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Menu;
using Tdms.Api.Components.Interfaces.Components.Menu;
using Tdms.Api.Components.Interfaces.Components.Table;
using static Tdms.Api.Components.Interfaces.Components.Table.ITableHeaderComponent;

namespace Tdms.Api.Components.Implementations.Components.Table
{
    public class TableHeaderComponent : ApplicationComponent, ITableHeaderComponent
    {
        private const string _SORT_ATTRIBUTE = "aria-sort";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Заголовок таблицы");

        private const string _DEFAULT_SELECTOR = "div[class^='x-column-header x-column-header-align-start']:not([aria-hidden='true'])";

        private const string _NAME_SELECTOR = "span[class*='x-column-header-text-inner']";

        private const string _TRIGGER_SELECTOR = "div[class*='x-column-header-trigger']";

        protected IWebComponent triggerComponent;

        protected IWebComponent nameComponent;

        protected TableHeaderComponent()
        {
            var triggerDescription = new Description(_TRIGGER_SELECTOR, "Триггер");

            var nameDescription = new Description(_NAME_SELECTOR, "Имя заголовка");

            triggerComponent = GetComponent()
                .WithDescription(triggerDescription)
                .Perform();

            nameComponent = GetComponent()
                .WithDescription(nameDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void Click() => Actions.Click();

        public IWebComponentBuilder<ITableFilterComponent> GetFilter() =>
            GetComponent<ITableFilterComponent>(typeof(TableFilterComponent));

        public string GetName() => nameComponent.Properties.GetText();

        public SortVariant GetSort()
        {
            return GetAttribute(_SORT_ATTRIBUTE, this) switch
            {
                "descending" => SortVariant.DESC,
                "ascending" => SortVariant.ASC,
                _ => SortVariant.None
            };
        }

        public void Hover() => Actions.Hover();

        public IWebComponentBuilder<IMenuComponent> ShowMenu()
        {
            IWebComponent.Context.GetComponent().WithDescription(new Description("div[id^='gridcolumn'][id*='triggerEl']", "123")).Perform().Actions.Hover();
            Actions.Hover();
            triggerComponent.Actions.Click();

            return IWebComponent.Context.GetComponent<IMenuComponent>(typeof(MenuComponent));
        }
    }
}
