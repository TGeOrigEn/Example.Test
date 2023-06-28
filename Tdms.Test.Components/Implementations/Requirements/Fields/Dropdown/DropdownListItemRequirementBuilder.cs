using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;
using Tdms.Api.Components.Interfaces.Requirements.Fields.Dropdown;

namespace Tdms.Api.Components.Implementations.Requirements.Fields.Dropdown
{
    public sealed class DropdownListItemRequirement<TComponent> : DropdownListItemRequirementBuilder<TComponent, DropdownListItemRequirement<TComponent>> where TComponent : IDropdownListItemComponent { }

    public sealed class DropdownListItemRequirement : DropdownListItemRequirementBuilder<IDropdownListItemComponent, DropdownListItemRequirement> { }

    public abstract class DropdownListItemRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, IDropdownListItemRequirementBuilder<TComponent, TBuilder>
        where TBuilder : DropdownListItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : IDropdownListItemComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
