namespace Tdms.Api.Components.Interfaces.Components.LoadIndicator
{
    public interface ILoadingComponent : IApplicationComponent
    {
        string GetMessage();

        void Wait(TimeSpan timeout);
    }
}
