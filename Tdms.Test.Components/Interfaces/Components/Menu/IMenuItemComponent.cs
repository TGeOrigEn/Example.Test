using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.Menu
{
    public interface IMenuItemComponent : IApplicationComponent
    {
        bool HasCheckBox();

        bool IsCheck();

        string GetName();

        void Hover();

        void Click();
    }
}
