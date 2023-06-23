using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Example.Test.Components
{
    public class LoadIndicatorComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Индикатор загрузки");

        private const string _DEFAULT_SELECTOR = "div[id^='loadmask'][class^='x-component x-border-box'][aria-hidden='false']";

        private const string _TEXT_COMPONENT_SELECTOR = "div[class*='x-mask-msg-text']";

        private IWebComponent _textComponent;

        protected LoadIndicatorComponent()
        {
            var textComponentDescription = new Description(_TEXT_COMPONENT_SELECTOR, "Текст индикатора загрузки");

            _textComponent = GetComponent()
                .WithDescription(textComponentDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public string GetText() => _textComponent.Properties.GetText();

        public LoadIndicatorComponent Wait(TimeSpan timeout)
        {
            var requirement = new WebComponentRequirement();

            this.Should(requirement.IsAvalable().Perform(), timeout);
            this.Should(requirement.IsAvalable(false).Perform(), timeout);

            if (this.Wait(requirement.IsAvalable().Perform(), TimeSpan.FromSeconds(1))) return Wait(timeout);
            else return this;
        }
    }
}
