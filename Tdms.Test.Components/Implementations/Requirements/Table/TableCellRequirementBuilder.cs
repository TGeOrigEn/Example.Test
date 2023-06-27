using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;
using Tdms.Api.Components.Interfaces.Requirements.Table;

namespace Tdms.Api.Components.Implementations.Requirements.Table
{
    public sealed class TableCellRequirement<TComponent> : TableCellRequirementBuilder<TComponent, TableCellRequirement<TComponent>> where TComponent : ITableCellComponent { }

    public sealed class TableCellRequirement : TableCellRequirementBuilder<ITableCellComponent, TableCellRequirement> { }

    public abstract class TableCellRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, ITableCellRequirementBuilder<TComponent, TBuilder>
        where TBuilder : TableCellRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITableCellComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasCheckBox(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasCheckBox(), flag, "Имеет флаго"));

        public virtual IOperationBuilder<TComponent, TBuilder> HasState(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasCheckBox(), flag, "Имеет состояние"));

        public virtual IOperationBuilder<TComponent, TBuilder> IsCheck(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsCheck(), flag, "Флаг"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByHeader(ITableHeaderComponent header)
        {
            int GetHeaderIndex()
            {
                var headerRequirement = new WebComponentRequirement<ITableHeaderComponent>();
                return header.Should(headerRequirement.IsAvalable().Perform()).Index;
            }

            var description = $"Ячейка относится к '{header.Hierarchy}'";

            return CreateBuilder(new Requirement<TComponent, int>(component => component.Index, () => GetHeaderIndex(), description));
        }

        public virtual IOperationBuilder<TComponent, TBuilder> ByStateEquality(int value) =>
            CreateBuilder(new Requirement<TComponent, int>(component => component.GetState(), value, "Имеет состояние"));
    }
}
