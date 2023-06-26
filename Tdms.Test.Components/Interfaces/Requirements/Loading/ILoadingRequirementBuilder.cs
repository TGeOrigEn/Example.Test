using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.LoadIndicator;

namespace Tdms.Api.Components.Interfaces.Requirements.LoadIndicator
{
    public interface ILoadingRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
    where TBuilder : ILoadingRequirementBuilder<TComponent, TBuilder>
    where TComponent : ILoadingComponent
    {
        new IOperationBuilder<TComponent, TBuilder> ByTextEquality(string value);

        new IOperationBuilder<TComponent, TBuilder> ByTextContent(string value);
    }
}
