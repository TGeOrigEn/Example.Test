using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Interfaces.Requirements.Table
{
    public interface ITableHeaderRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ITableHeaderRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITableHeaderComponent
    {
        IOperationBuilder<TComponent, TBuilder> BySortEquality(ITableHeaderComponent.SortVariant value);

        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}
