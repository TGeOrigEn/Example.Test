using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.LoadIndicator;

namespace Tdms.Api.Components.Interfaces.Requirements.LoadIndicator
{
    public interface ILoadingRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
    where TBuilder : ILoadingRequirementBuilder<TComponent, TBuilder>
    where TComponent : ILoadingComponent
    {
        IOperationBuilder<TComponent, TBuilder> ByMessageEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByMessageContent(string value);
    }
}
