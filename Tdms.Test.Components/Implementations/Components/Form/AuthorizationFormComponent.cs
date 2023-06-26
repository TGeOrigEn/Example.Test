using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Components.Fields;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Implementations.Requirements.Fields;
using Tdms.Api.Components.Interfaces.Components.Buttons;
using Tdms.Api.Components.Interfaces.Components.Field;
using Tdms.Api.Components.Interfaces.Components.Forms;

namespace Tdms.Api.Components.Implementations.Components.Form
{
    public class AuthorizationFormComponent : ApplicationComponent, IAuthorizationFormComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Форма авторизации");

        private const string _DEFAULT_SELECTOR = "div[id^='form'][class*='x-panel ']";

        public IFieldComponent UsernameField { get; }

        public IFieldComponent PasswordField { get; }

        public IButtonComponent LogInButton { get; }

        protected AuthorizationFormComponent()
        {
            var usernameFieldRequirement = new FieldRequirement()
                .ByLabelEquality("Пользователь:")
                .Perform();

            var passwordFieldRequirement = new FieldRequirement()
                .ByLabelEquality("Пароль:")
                .Perform();

            var loginButtonRequirement = new ButtonRequirement()
                .HasName()
                .And()
                .ByNameEquality("Войти")
                .Perform();

            UsernameField = GetComponent<FieldComponent>()
                .WithRequirement(usernameFieldRequirement)
                .Perform();

            PasswordField = GetComponent<FieldComponent>()
                .WithRequirement(passwordFieldRequirement)
                .Perform();

            LogInButton = GetComponent<ButtonComponent>()
                .WithRequirement(loginButtonRequirement)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void LogIn(string username, string password)
        {
            UsernameField.SetValue(username);
            PasswordField.SetValue(password);
            LogInButton.Click();
        }
    }
}
