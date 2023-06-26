using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components
{
    public interface IApplicationComponent : IWebComponent
    {
        bool HasReference();

        bool HasTip();

        string GetReference();

        string GetTip();
    }
}
