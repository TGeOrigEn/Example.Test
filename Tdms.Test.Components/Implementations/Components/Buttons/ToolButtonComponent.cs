using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Tdms.Api.Components.Implementations.Components.Buttons
{
    public class ToolButtonComponent : ButtonComponent
    {
        public static new IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Кнопка инструмента");

        private const string _DEFAULT_SELECTOR = "*[class^='x-tool x-box-item x-tool-default x-tool-']:not([style*='display'])";

        protected ToolButtonComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
