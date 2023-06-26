namespace Tdms.Api.Components.Interfaces.Components.LoadIndicator
{
    public interface ILoadingComponent : IApplicationComponent
    {
        string GetText();

        void Wait(TimeSpan timeout);
    }
}
