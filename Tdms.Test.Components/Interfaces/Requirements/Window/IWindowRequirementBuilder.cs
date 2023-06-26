using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Window;

namespace Tdms.Api.Components.Interfaces.Requirements.Window
{
    public interface IWindowRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IWindowRequirementBuilder<TComponent, TBuilder>
        where TComponent : IWindowComponent
    {
        IOperationBuilder<TComponent, TBuilder> ByTitleEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByTitleContent(string value);
    }
}
