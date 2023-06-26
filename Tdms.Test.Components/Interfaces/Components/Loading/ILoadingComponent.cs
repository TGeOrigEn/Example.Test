namespace Example.Test.Interfaces.Components.LoadIndicator
{
    public interface ILoadingComponent : IApplicationComponent
    {
        string GetText();

        void Wait(TimeSpan timeout);
    }
}
