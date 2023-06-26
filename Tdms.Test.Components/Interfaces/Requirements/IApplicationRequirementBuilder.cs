using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components;

namespace Tdms.Api.Components.Interfaces.Requirements
{
    public interface IApplicationRequirementBuilder<TComponent, TBuilder> : IRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TComponent : IApplicationComponent
    {
        IOperationBuilder<TComponent, TBuilder> HasReference(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> HasTip(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> ByReferenceEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByTipEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByReferenceContent(string value);

        IOperationBuilder<TComponent, TBuilder> ByTipContent(string value);
    }
}
