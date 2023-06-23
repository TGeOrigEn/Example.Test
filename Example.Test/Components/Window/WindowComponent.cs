using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components.Menu;

namespace Example.Test.Components.Window
{
    public class WindowComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Окно");

        private const string _DEFAULT_SELECTOR = "div[id^='window'][class^='x-window x-layer']";

        private const string _TITLE_COMPONENT_SELECTOR = "div[id*='header-title'][class*='x-title-text']";

        protected WindowComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
