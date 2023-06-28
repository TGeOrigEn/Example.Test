namespace Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List
{
    public interface IDropdownListItemComponent : IApplicationComponent
    {
        string GetName();

        void Click();
    }
}
