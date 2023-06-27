using Tdms.Api.Components.Interfaces.Components.Buttons;
using Tdms.Api.Components.Interfaces.Components.Field;

namespace Tdms.Api.Components.Interfaces.Components.Forms
{
    public interface IAuthorizationFormComponent : IApplicationComponent
    {
        public IFieldComponent UsernameField { get; }

        public IFieldComponent PasswordField { get; }

        public IButtonComponent LogInButton { get; }

        public IAuthorizationFormComponent LogIn(string username, string password);
    }
}
