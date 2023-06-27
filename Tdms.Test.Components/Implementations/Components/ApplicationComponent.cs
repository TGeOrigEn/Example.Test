using Empyrean.Core.Exceptions;
using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using System;
using Tdms.Api.Components.Interfaces.Components;

namespace Tdms.Api.Components.Implementations.Components
{
    public abstract class ApplicationComponent : WebComponent, IApplicationComponent
    {
        private const string _REFERENCE_ATTRIBUTE = "data-reference";

        private const string _TIP_ATTRIBUTE = "data-qtip";

        protected IWebComponent referenceComponent;

        protected IWebComponent tipComponent;

        protected ApplicationComponent()
        {
            referenceComponent = this;
            tipComponent = this;
        }

        public virtual string GetReference() => GetAttribute(_REFERENCE_ATTRIBUTE, referenceComponent);

        public virtual string GetTip() => GetAttribute(_TIP_ATTRIBUTE, tipComponent);

        public virtual bool HasReference() => HasAttribute(_REFERENCE_ATTRIBUTE, referenceComponent);

        public virtual bool HasTip() => HasAttribute(_TIP_ATTRIBUTE, tipComponent);

        protected static string GetAttribute(string attributeName, IWebComponent attributeComponent) =>
            attributeComponent.Properties.GetAttribute(attributeName) ?? string.Empty;

        protected static bool HasAttribute(string attributeName, IWebComponent attributeComponent)
        {
            var availabilityRequirement = new WebComponentRequirement().IsAvalable().Perform();

            if (attributeComponent.Has(availabilityRequirement, TimeSpan.Zero))
                return attributeComponent.Properties.GetAttribute(attributeName) != null;

            return false;
        }

        protected static string GetValue(IWebComponent inputComponent) => inputComponent.Properties.GetValue()
            ?? throw new WebComponentException($"Веб-компонент '{inputComponent.Hierarchy}' не имеет атрибут 'value'.");
    }
}
