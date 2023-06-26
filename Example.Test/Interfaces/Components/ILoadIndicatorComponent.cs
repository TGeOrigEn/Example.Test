namespace Example.Test.Interfaces.Components
{
    public interface ILoadIndicatorComponent : IApplicationComponent
    {
        void Wait(TimeSpan timeout);
    }
}
