using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Field;

namespace Example.Test.Interfaces.Requirements.Fields
{
    public interface IFieldRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IFieldRequirementBuilder<TComponent, TBuilder>
        where TComponent : IFieldComponent
    {
        IOperationBuilder<TComponent, TBuilder> HasPlaceholder(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> HasLabel(bool flag = true);

        new IOperationBuilder<TComponent, TBuilder> IsReadOnly(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> ByPlaceholderEquality(string value);

        new IOperationBuilder<TComponent, TBuilder> ByValueEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByLabelEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByPlaceholderContent(string value);

        new IOperationBuilder<TComponent, TBuilder> ByValueContent(string value);

        IOperationBuilder<TComponent, TBuilder> ByLabelContent(string value);
    }
}
