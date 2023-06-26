using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Buttons;

namespace Tdms.Api.Components.Interfaces.Requirements.Buttons
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
