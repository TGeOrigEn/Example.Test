using Empyrean.Core.Interfaces;

namespace Tdms.Api.Components.Interfaces.Components
{
    public interface IApplicationComponent : IWebComponent
    {
        bool HasReference();

        bool HasTip();

        string GetReference();

        string GetTip();
    }
}
