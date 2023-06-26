using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.TabBar;

namespace Tdms.Api.Components.Interfaces.Requirements.Tab
{
    public interface ITabRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ITabRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITabComponent
    {
        IOperationBuilder<TComponent, TBuilder> IsActive(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}
