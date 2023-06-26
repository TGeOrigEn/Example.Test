namespace Example.Test.Interfaces.Components.Button
{
    public interface IButtonComponent : IApplicationComponent
    {
        bool HasName();

        string GetName();

        void Click();
    }
}
