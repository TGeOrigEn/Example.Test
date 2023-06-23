using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Example.Test.Components.Buttons
{
    public class ButtonComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Кнопка");

        private const string _DEFAULT_SELECTOR = "*[id^='button'][class^='x-btn'][class*='x-unselectable']:not([style*='display'])";

        private const string _TEXT_COMPONENT_SELECTOR = "span[class*='x-btn-text']";

        private readonly IWebComponent _textComponent;

        protected ButtonComponent()
        {
            var textComponentDescription = new Description(_TEXT_COMPONENT_SELECTOR, "Текст кнопки");

            _textComponent = GetComponent()
                .WithDescription(textComponentDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public bool HasTip() => Properties.GetAttribute("data-qtip") != null;

        public bool HasText() => _textComponent.Has(new WebComponentRequirement().IsAvalable(true).And().IsDisplayed(true).Perform(), TimeSpan.Zero);

        public string GetText() => _textComponent.Properties.GetText();

        public string? GetTip() => Properties.GetAttribute("data-qtip");

        public void Click() => Actions.Click();
    }
}
