using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown;

namespace Tdms.Api.Components.Implementations.Components.Fields.Dropdown
{
    public class DropdownFieldComponent : FieldComponent, IDropdownFieldComponent
    {
        private const string _TRIGGER_SELECTOR = "div[id*='trigger-picker']";

        protected IWebComponent triggerComponent;

        protected DropdownFieldComponent()
        {
            var triggerDescription = new Description(_TRIGGER_SELECTOR, "Кнопка-триггер");

            triggerComponent = GetComponent()
                .WithDescription(triggerDescription)
                .Perform();
        }

        public IWebComponentBuilder<TComponent> ShowList<TComponent>() where TComponent : IApplicationComponent
        {
            triggerComponent.Actions.Click();
            return IWebComponent.Context.GetComponent<TComponent>();
        }
    }
}
