using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Interfaces.Components.Buttons;
using Tdms.Api.Components.Interfaces.Components.Window;

namespace Tdms.Api.Components.Implementations.Components.Window
{
    public class WindowComponent : ApplicationComponent, IWindowComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Окно");

        private const string _DEFAULT_SELECTOR = "div[class^='x-window x-layer']";

        private const string _HEADER_SELECTOR = "div[class^='x-window-header']";

        private const string _FOOTER_SELECTOR = "div[id^='panel'][class^='x-panel x-docked']";

        private const string _TITLE_SELECTOR = "div[id*='header-title'][class*='x-title-text']";

        protected IWebComponent headerComponent;

        protected IWebComponent footerComponent;

        protected IWebComponent titleComponent;

        protected IButtonComponent maximizeButton;

        protected IButtonComponent closeButton;

        protected IButtonComponent cancelButton = null!;

        protected IButtonComponent applyButton = null!;

        protected IButtonComponent okButton = null!;

        protected IButtonComponent yesButton = null!;

        protected IButtonComponent noButton = null!;

        protected WindowComponent()
        {
            var nameDescription = new Description(_TITLE_SELECTOR, "Заголовок окна");

            var footerDescription = new Description(_FOOTER_SELECTOR, "Нижний колонтитул окна");

            var headerDescription = new Description(_HEADER_SELECTOR, "Верхний колонтитул окна");

            var toolButtonRequirement = new ButtonRequirement<ToolButtonComponent>();

            var buttonRequirement = new ButtonRequirement<ButtonComponent>();

            var maximizeRequirement = toolButtonRequirement.HasTip(false).Perform();

            var closeRequirement = toolButtonRequirement.HasTip().And().ByTipContent("закрыть").Perform();

            headerComponent = GetComponent()
                .WithDescription(headerDescription)
                .Perform();

            footerComponent = GetComponent()
                .WithDescription(footerDescription)
                .Perform();

            titleComponent = headerComponent.GetComponent()
                .WithDescription(nameDescription)
                .Perform();

            maximizeButton = headerComponent.GetComponent<ToolButtonComponent>()
                .WithRequirement(maximizeRequirement)
                .Perform();

            closeButton = headerComponent.GetComponent<ToolButtonComponent>()
                .WithRequirement(closeRequirement)
                .Perform();

            InitializeButtons(footerComponent);
        }

        protected virtual void InitializeButtons(IWebComponent footerComponent)
        {
            var buttonRequirement = new ButtonRequirement<ButtonComponent>();

            var cancelRequirement = buttonRequirement.ByNameEquality("Отмена").Perform();

            var applyRequirement = buttonRequirement.ByNameEquality("Принять").Perform();

            var yesRequirement = buttonRequirement.ByNameEquality("Да").Perform();

            var noRequirement = buttonRequirement.ByNameEquality("Нет").Perform();

            var okRequirement = buttonRequirement.ByNameEquality("Ок").Perform();

            cancelButton = footerComponent.GetComponent<ButtonComponent>()
                .WithRequirement(cancelRequirement)
                .Perform();

            applyButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(applyRequirement)
               .Perform();

            yesButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(yesRequirement)
               .Perform();

            okButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(okRequirement)
               .Perform();

            noButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(noRequirement)
               .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Apply() => applyButton.Click();

        public virtual void Cancel() => cancelButton.Click();

        public virtual void Close() => closeButton.Click();

        public virtual string GetTitle() => titleComponent.Properties.GetText();

        public virtual void Maximize() => maximizeButton.Click();

        public virtual void Ok() => okButton.Click();

        public void Yes() => yesButton.Click();

        public void No() => noButton.Click();
    }
}
