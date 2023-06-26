using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Button;

namespace Example.Test.Interfaces.Requirements.Button
{
    public interface IButtonRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IButtonRequirementBuilder<TComponent, TBuilder>
        where TComponent : IButtonComponent
    {
        new IOperationBuilder<TComponent, TBuilder> ByTextEquality(string value);

        new IOperationBuilder<TComponent, TBuilder> ByTextContent(string value);
    }
}
