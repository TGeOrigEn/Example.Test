using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.LoadIndicator;

namespace Example.Test.Interfaces.Requirements.LoadIndicator
{
    public interface ILoadingRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
    where TBuilder : ILoadingRequirementBuilder<TComponent, TBuilder>
    where TComponent : ILoadingComponent
    {
        new IOperationBuilder<TComponent, TBuilder> ByTextEquality(string value);

        new IOperationBuilder<TComponent, TBuilder> ByTextContent(string value);
    }
}
