using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Window;

namespace Example.Test.Interfaces.Requirements.Window
{
    public interface IWindowRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IWindowRequirementBuilder<TComponent, TBuilder>
        where TComponent : IWindowComponent
    {
        IOperationBuilder<TComponent, TBuilder> ByTitleEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByTitleContent(string value);
    }
}
