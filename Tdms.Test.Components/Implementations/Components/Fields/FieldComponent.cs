using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Field;
using OpenQA.Selenium;

namespace Tdms.Api.Components.Implementations.Components.Fields
{
    public class FieldComponent : ApplicationComponent, IFieldComponent
    {
        private const string _PLACEHOLDER_ATTRIBUTE = "placeholder";

        private const string _READONLY_ATTRIBUTE = "readonly";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Поле");

        private const string _DEFAULT_SELECTOR = "div[class^='x-field']:not([style*='display'])";

        private const string _LABEL_SELECTOR = "input[class*='x-form-field']";

        private const string _INPUT_SELECTOR = "span[class*='label-text']";

        protected IWebComponent labelComponent;

        protected IWebComponent inputComponent;

        protected FieldComponent()
        {
            var labelDescription = new Description(_LABEL_SELECTOR, "Заголовок поля");

            var inputDescription = new Description(_INPUT_SELECTOR, "Ввод поля");

            labelComponent = GetComponent()
                .WithDescription(labelDescription)
                .Perform();     

            inputComponent = GetComponent()
                .WithDescription(inputDescription)
                .Perform();
        }

        public virtual void Clear() => inputComponent.Actions.Clear();

        public virtual string GetLabel() => labelComponent.Properties.GetText();

        public virtual string GetPlaceholder() => GetAttribute(_PLACEHOLDER_ATTRIBUTE, inputComponent);

        public virtual string GetValue() => GetValue(inputComponent);

        public virtual bool HasLabel() => labelComponent.IsAvalable();

        public virtual bool HasPlaceholder() => HasAttribute(_PLACEHOLDER_ATTRIBUTE, inputComponent);

        public virtual bool IsReadOnly() => HasAttribute(_READONLY_ATTRIBUTE, inputComponent);

        public virtual void SendKeys(string keys) => inputComponent.Actions.SendKeys(keys);

        public virtual void SetValue(string value) => inputComponent.Actions.SetValue(value);

        public virtual void Sumbit() => inputComponent.Actions.SendKeys(Keys.Enter);
    }
}
