using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Example.Test.Components.Buttons
{
    public class ToolButtonComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Кнопка-инструмент");

        private const string _DEFAULT_SELECTOR = "*[class^='x-tool x-box-item x-tool-default x-tool-']:not([style*='display'])";

        protected ToolButtonComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public bool HasTip() => Properties.GetAttribute("data-qtip") != null;

        public string? GetTip() => Properties.GetAttribute("data-qtip");

        public void Click() => Actions.Click();
    }
}
