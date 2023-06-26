using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Table;

namespace Example.Test.Interfaces.Requirements.Table
{
    public interface ITableCellRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ITableCellRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITableCellComponent
    {
        IOperationBuilder<TComponent, TBuilder> HasCheckBox(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> HasState(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> IsCheck(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> ByHeader(ITableHeaderComponent header);

        IOperationBuilder<TComponent, TBuilder> ByStateEquality(int value);

        new IOperationBuilder<TComponent, TBuilder> ByValueEquality(string value);

        new IOperationBuilder<TComponent, TBuilder> ByValueContent(string value);
    }
}
