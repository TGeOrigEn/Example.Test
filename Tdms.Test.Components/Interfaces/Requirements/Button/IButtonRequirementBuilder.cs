using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Button;

namespace Example.Test.Interfaces.Requirements.Button
{
    public interface IButtonRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IButtonRequirementBuilder<TComponent, TBuilder>
        where TComponent : IButtonComponent
    {
        IOperationBuilder<TComponent, TBuilder> HasName(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}
