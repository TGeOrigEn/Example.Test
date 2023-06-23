using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components.Buttons;
using Example.Test.Components.Fields;
using Example.Test.Requirements.Buttons;
using Example.Test.Requirements.Fields;

namespace Example.Test.Components.Forms
{
    public class AuthorizationFormComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Форма авторизации");

        private const string _DEFAULT_SELECTOR = "div[id^='form'][class*='x-panel ']";

        public FieldComponent UsernameField { get; }

        public FieldComponent PasswordField { get; }

        public ButtonComponent LoginButton { get; }

        protected AuthorizationFormComponent()
        {
            var usernameFieldRequirement = new FieldRequirement()
                .ByLabelEquality("Пользователь:")
                .Perform();

            var passwordFieldRequirement = new FieldRequirement()
                .ByLabelEquality("Пароль:")
                .Perform();

            var loginButtonRequirement = new ButtonRequirement()
                .HasText()
                .And()
                .ByTextEquality("Войти")
                .Perform();

            UsernameField = GetComponent<FieldComponent>()
                .WithRequirement(usernameFieldRequirement)
                .Perform();

            PasswordField = GetComponent<FieldComponent>()
                .WithRequirement(passwordFieldRequirement)
                .Perform();

            LoginButton = GetComponent<ButtonComponent>()
                .WithRequirement(loginButtonRequirement)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void LogIn(string username, string password)
        {
            UsernameField.SetValue(username);
            PasswordField.SetValue(password);
            LoginButton.Click();
        }
    }
}
