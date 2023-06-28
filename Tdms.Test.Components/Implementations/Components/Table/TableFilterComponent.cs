using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Fields.Dropdown.List;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Implementations.Components.Table
{
    public class TableFilterComponent : ApplicationComponent, ITableFilterComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Фильтр таблицы");

        private const string _DEFAULT_SELECTOR = "div[id^='contentfilter'][id*='bodyEl']";

        private const string _TRIGGER_SELECTOR = "div[id*='trigger-picker']";

        private const string _INPUT_SELECTOR = "input[class*='x-form-field']";

        protected IWebComponent triggerComponent;

        protected IWebComponent inputComponent;

        protected TableFilterComponent()
        {
            var triggerDescription = new Description(_TRIGGER_SELECTOR, "Кнопка-триггер");

            var inputDescription = new Description(_INPUT_SELECTOR, "Ввод фильтра");

            triggerComponent = GetComponent()
                .WithDescription(triggerDescription)
                .Perform();

            inputComponent = GetComponent()
                .WithDescription(inputDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void SetValue(string value) => inputComponent.Actions.SetValue(value);

        public void SendKeys(string keys) => inputComponent.Actions.SendKeys(keys);

        public void Clear() => inputComponent.Actions.Clear();

        public virtual IWebComponentBuilder<IDropdownListComponent> ClickOnTrigger()
        {
            triggerComponent.Actions.Click();
            return IWebComponent.Context.GetComponent<IDropdownListComponent>(typeof(DropdownListComponent));
        }

        public string GetValue() => inputComponent.Properties.GetValue()
            ?? throw new System.Exception();
    }
}
