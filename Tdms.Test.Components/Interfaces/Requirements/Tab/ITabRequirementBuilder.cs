using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.TabBar;

namespace Example.Test.Interfaces.Requirements.Tab
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
