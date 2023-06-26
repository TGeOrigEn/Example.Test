namespace Tdms.Api.Components.Interfaces.Components.Buttons
{
    public interface IButtonComponent : IApplicationComponent
    {
        bool HasName();

        string GetName();

        void Click();
    }
}
