using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Buttons;

namespace Tdms.Api.Components.Interfaces.Requirements.Fields.Dropdown
{
    public interface IDropdownListItemRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IDropdownListItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : IButtonComponent
    {
        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}
