using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Button;

namespace Tdms.Test.Components.Implementations.Components.Buttons
{
    public class ButtonComponent : ApplicationComponent, IButtonComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Кнопка");

        private const string _DEFAULT_SELECTOR = "*[id^='button'][class^='x-btn'][class*='x-unselectable']:not([style*='display'])";

        private const string _NAME_SELECTOR = "span[class*='x-btn-text']";

        protected IWebComponent nameComponent;

        protected ButtonComponent()
        {
            var nameComponentDescription = new Description(_NAME_SELECTOR, "Название кнопки");

            nameComponent = GetComponent()
                .WithDescription(nameComponentDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual bool HasName() => nameComponent.IsAvalable();

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual void Click() => Actions.Click();
    }
}
