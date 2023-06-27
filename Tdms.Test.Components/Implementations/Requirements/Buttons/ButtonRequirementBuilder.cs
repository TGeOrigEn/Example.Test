using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Buttons;
using Tdms.Api.Components.Interfaces.Requirements.Buttons;
using Tdms.Api.Components.Implementations.Components.Buttons;

namespace Tdms.Api.Components.Implementations.Requirements.Buttons
{
    public sealed class ButtonRequirement<TComponent> : ButtonRequirementBuilder<TComponent, ButtonRequirement<TComponent>> where TComponent : IButtonComponent { }

    public sealed class ButtonRequirement : ButtonRequirementBuilder<IButtonComponent, ButtonRequirement> { }

    public abstract class ButtonRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, IButtonRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ButtonRequirementBuilder<TComponent, TBuilder>
        where TComponent : IButtonComponent
    {
        public IOperationBuilder<TComponent, TBuilder> HasName(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasName(), flag, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
