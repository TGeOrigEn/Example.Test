using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using System;
using Tdms.Api.Components.Interfaces.Components.LoadIndicator;

namespace Tdms.Api.Components.Implementations.Components.Loading
{
    public class LoadingComponent : ApplicationComponent, ILoadingComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Индикатор загрузки");

        private const string _DEFAULT_SELECTOR = "div[id^='loadmask'][class^='x-component x-border-box'][aria-hidden='false']";

        private const string _MESSAGE_SELECTOR = "div[class*='x-mask-msg-text']";

        private IWebComponent _messageComponent;

        protected LoadingComponent()
        {
            var messageDescription = new Description(_MESSAGE_SELECTOR, "Текст загрузки");

            _messageComponent = GetComponent()
                .WithDescription(messageDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual string GetMessage() => _messageComponent.Properties.GetText();

        public virtual void Wait(TimeSpan timeout)
        {
            var requirement = new WebComponentRequirement();

            this.Has(requirement.IsAvalable().Perform(), timeout);
            this.Has(requirement.IsAvalable(false).Perform(), timeout);

            if (this.Until(requirement.IsAvalable().Perform(), TimeSpan.FromSeconds(1)))
                Wait(timeout);
        }
    }
}
