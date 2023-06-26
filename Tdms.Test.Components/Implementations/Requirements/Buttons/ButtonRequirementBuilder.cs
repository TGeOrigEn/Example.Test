using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Button;
using Example.Test.Interfaces.Requirements.Button;
using Tdms.Test.Components.Implementations.Components.Buttons;

namespace Tdms.Test.Components.Implementations.Requirements.Buttons
{
    public sealed class ButtonRequirement<TComponent> : ButtonRequirementBuilder<TComponent, ButtonRequirement<TComponent>> where TComponent : IButtonComponent { }

    public sealed class ButtonRequirement : ButtonRequirementBuilder<ButtonComponent, ButtonRequirement> { }

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
