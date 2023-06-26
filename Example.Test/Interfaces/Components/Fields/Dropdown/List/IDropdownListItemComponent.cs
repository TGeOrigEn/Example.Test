using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.Field.Dropdown.List
{
    public interface IDropdownListItemComponent : IWebComponent
    {
        string GetName();

        void Click();
    }
}
