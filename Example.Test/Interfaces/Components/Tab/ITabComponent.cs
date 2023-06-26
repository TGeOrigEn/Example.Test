namespace Example.Test.Interfaces.Components.TabBar
{
    public interface ITabComponent : IApplicationComponent
    {
        bool IsActive();

        string GetName();

        void Close();

        void Click();
    }
}
