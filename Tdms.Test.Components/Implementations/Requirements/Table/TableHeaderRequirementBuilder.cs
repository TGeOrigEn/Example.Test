using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;
using Tdms.Api.Components.Interfaces.Requirements.Table;
using static Tdms.Api.Components.Interfaces.Components.Table.ITableHeaderComponent;

namespace Tdms.Api.Components.Implementations.Requirements.Table
{
    public sealed class TableHeaderRequirement<TComponent> : TableHeaderRequirementBuilder<TComponent, TableHeaderRequirement<TComponent>> where TComponent : ITableHeaderComponent { }

    public sealed class TableHeaderRequirement : TableHeaderRequirementBuilder<ITableHeaderComponent, TableHeaderRequirement> { }

    public abstract class TableHeaderRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, ITableHeaderRequirementBuilder<TComponent, TBuilder>
        where TBuilder : TableHeaderRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITableHeaderComponent
    {
        public IOperationBuilder<TComponent, TBuilder> BySortEquality(SortVariant value) =>
            CreateBuilder(new Requirement<TComponent, SortVariant>(component => component.GetSort(), value, "Сортировка"));

        public IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
