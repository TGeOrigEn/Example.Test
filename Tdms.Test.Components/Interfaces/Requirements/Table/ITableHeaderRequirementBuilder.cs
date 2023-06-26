using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Table;

namespace Example.Test.Interfaces.Requirements.Table
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
