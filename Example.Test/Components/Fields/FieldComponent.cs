using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Example.Test.Components.Fields
{
    public class FieldComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Поле");

        private const string _DEFAULT_SELECTOR = "div[class^='x-field']:not([style*='display'])";

        private const string _LABEL_COMPONENT_SELECTOR = "span[class*='label-text']";

        private const string _INPUT_COMPONENT_SELECTOR = "input[class*='x-form-field']";

        private readonly IWebComponent _inputComponent;

        private readonly IWebComponent _labelComponent;

        protected FieldComponent()
        {
            var labelComponentDescription = new Description(_LABEL_COMPONENT_SELECTOR, "Заголовок поля");

            _labelComponent = GetComponent()
                .WithDescription(labelComponentDescription)
                .Perform();

            var inputComponentDescription = new Description(_INPUT_COMPONENT_SELECTOR, "Ввод поля");

            _inputComponent = GetComponent()
                .WithDescription(inputComponentDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public bool HasLabel() => _labelComponent.Has(new WebComponentRequirement().IsAvalable(true).And().IsDisplayed(true).Perform(), TimeSpan.Zero);

        public string GetLabel() => _labelComponent.Properties.GetText();

        public string GetValue() => _inputComponent.Properties.GetValue()!;

        public void SetValue(string value) => _inputComponent.Actions.SetValue(value);

        public void SendKeys(string keys) => _inputComponent.Actions.SendKeys(keys);

        public void Clear() => _inputComponent.Actions.Clear();
    }
}
