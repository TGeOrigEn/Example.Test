using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Button;

namespace Example.Test.Interfaces.Requirements.Fields.Dropdown
{
    public interface IDropdownListItemRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IDropdownListItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : IButtonComponent
    {
        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}
