namespace Example.Test.Interfaces.Components.TabBar
{
    public interface ITabComponent : IApplicationComponent
    {
        bool IsSelected();

        string GetName();

        void Close();

        void Click();
    }
}
