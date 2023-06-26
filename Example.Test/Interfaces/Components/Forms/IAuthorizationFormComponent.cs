using Example.Test.Interfaces.Components.Button;
using Example.Test.Interfaces.Components.Field;

namespace Example.Test.Interfaces.Components.Forms
{
    public interface IAuthorizationFormComponent : IApplicationComponent
    {
        public IFieldComponent UsernameField { get; }

        public IFieldComponent PasswordField { get; }

        public IButtonComponent LogInButton { get; }

        public void LogIn(string username, string password);
    }
}
